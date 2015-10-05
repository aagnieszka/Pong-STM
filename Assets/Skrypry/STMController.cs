using System;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class STMController : MonoBehaviour
{
   
    public String nazwaPortu;
   
    private SerialPort stm;
    
    private Thread stmThread;
    
    private System.Object odchyleniaMut = new System.Object();
   
    public Vector3 odchylenia = new Vector3();
  
    public Vector3 predkosci = new Vector3();

	// Use this for initialization
    void Start()
    {
        
        stm = new SerialPort("COM3", 38400, Parity.None, 8, StopBits.One);
       
        try
        {
            stm.Open();
            if (!stm.IsOpen)
            {
                
                Debug.LogWarning("Nie udalo sie otworzyc polaczenia z portem: " + nazwaPortu);
                Destroy(this);
            }
            else
            {
                Debug.Log("Otwarto polaczenie z portem: " + nazwaPortu);
                
                stmThread = new Thread(stmOdczyt);
                stmThread.Start();
            }
        }
        catch (Exception e)
        {
            
            Debug.LogWarning("Nie udalo sie otworzyc polaczenia z portem: " + nazwaPortu);
            Destroy(this);
        }
	}

    
    private void stmOdczyt()
    {
  
        while (true)
        {
           
            Vector3 odchylenia_l = new Vector3();
          
            lock (stm)
            {
               
                if (!stm.IsOpen) break;
                
                odchylenia_l.x = stm.ReadByte();
                odchylenia_l.y = stm.ReadByte();
                odchylenia_l.z = stm.ReadByte();
                
                
                if (odchylenia_l.x > 127)
                {
                    odchylenia_l.x -= 256;
                }
                if (odchylenia_l.y > 127)
                {
                    odchylenia_l.y -= 256;
                }
                if (odchylenia_l.z > 127)
                {
                    odchylenia_l.z -= 256;
                }
            }
           
            lock (odchyleniaMut)
            {
                odchylenia = odchylenia_l;
            }
        }
    }

	// Update is called once per frame
    
	void Update ()
	{
        Vector3 odchylenia_l;
        
	    lock (odchyleniaMut)
	    {
           
	        odchylenia_l = odchylenia;
	    }
       
	    Vector3 przesuniecie = predkosci;
	    przesuniecie.Scale(odchylenia_l);
	    przesuniecie /= 127;
        
	    przesuniecie *= Time.deltaTime;
        
        transform.Translate(przesuniecie);
	}

    
    void OnDestroy()
    {
        
        lock (stm)
        {
            
            if (stm.IsOpen)
            {
                
                stm.Close();
                Debug.Log("Zamkniecie polaczenia z portem: "+nazwaPortu);
            }
        }
    }
}
