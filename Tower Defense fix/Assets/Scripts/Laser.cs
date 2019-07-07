using UnityEngine;

public class Laser : MonoBehaviour {

    private LineRenderer laser;
    bool isGreen = false;
    public string nextScene;
    // Use this for initialization
    void Start () {
        laser = GetComponent<LineRenderer>();
        transform.localScale = new Vector3();
    }
	

	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            ChangeColor(false);
        }
        else
        {
            ChangeColor(true);
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {

            LaserOff();
        }
        else
        {
            ShootLaser();
        }
	}

    public void ChangeColor(bool isGreen)
    {
        this.isGreen = isGreen;
        Color c = isGreen ? Color.green : Color.white;
        laser.startColor = c;
    }

    void LaserOff()
    {
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, transform.position);
    }
    void ShootLaser()
    {
        laser.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            
            if (hit.collider)
            {
                laser.SetPosition(1, hit.point);
                if(!isGreen){
                    if (hit.collider.tag == "Node")
                    {
                        //Application.LoadLevel("CutScene1");
                        //hit.collider.gameObject.transform.GetComponent<Node>().OnMouseEnter();
                        hit.collider.gameObject.transform.GetComponent<Node>().OnMouseDown();
                        return;
                        //hit.collider.gameObject.transform.GetComponent<Node>().OnMouseExit();
                        //Node.nodeInstance.OnMouseEnter();
                        //Node.nodeInstance.OnMouseDown();

                    }else if(hit.collider.tag == "Item1")
                    {
                        Shop.shopInstance.SelectStandardTurret();
                    }else if (hit.collider.tag == "Item2")
                    {
                        Shop.shopInstance.SelectMissileLauncher();
                    }else if (hit.collider.tag == "Retry")
                    {
                        Time.timeScale = 1;
                        Application.LoadLevel("Level01");
                    }
                    else if (hit.collider.tag == "Menu")
                    {
                        Time.timeScale = 1;
                        Application.LoadLevel("MainMenu2");
                    }else if (hit.collider.tag == "Upgrade")
                    {
                        NodeUI.nodeUIInstance.Upgrade();
                    }else if (hit.collider.tag == "Sell")
                    {
                        NodeUI.nodeUIInstance.Sell();
                    }
                    else if (hit.collider.tag == "Next")
                    {
                        EndCutscene.endCutInstance.ChangeSpriteAdd();
                    }
                    else if (hit.collider.tag == "Prev")
                    {
                        EndCutscene.endCutInstance.ChangeSpriteMin();
                    }
                    else if (hit.collider.tag == "Exit")
                    {
                        Application.Quit();
                    }
                    else{
                        Application.LoadLevel(nextScene);
                        Destroy(hit.transform.gameObject);
                    }

                }
            }
        }
        else
        {
            laser.SetPosition(1, transform.forward * 5000);
        }
    }
}


