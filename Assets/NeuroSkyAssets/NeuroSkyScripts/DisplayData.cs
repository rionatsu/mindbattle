using UnityEngine;
using System.Collections;


public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;

	private int indexSignalIcons = 1;

	TGCConnectionController controller;

	int poorSignal1;
	int attention1;
	int meditation1;

	float delta;

	int blink1;
	int blinkcounter = 0;

    int Rawdata;

    float Theta;
    float LowAlpha;
    float HighAlpha;
    float LowBeta;
    float HighBeta;
    float LowGamma;
    float HighGamma;

    int counter;
	int counter2;

	public int mode;//none:0, 1:attack,2:defence
	int attack_counter ;

	public int getmode(){
		//if(mode == 1){
		//	if( attack_counter>=0){
		//		return 0;
		//	}
		//	attack_counter = 20;
		//}
		return mode;
	}

	void learning()
	{        
        counter2 = (counter2 + 1) % 10;
		if (counter2 == 0)
        {
			System.IO.File.Copy("result","result2",true);

			System.IO.StreamReader reader = new System.IO.StreamReader("result2");
			string line = reader.ReadLine();
			string sep = line.Substring(0,3);//1.00000000+なんちゃら　の先頭だけとる
			//Debug.Log(sep);
			int temp_mode = (int)float.Parse(sep);//1.0をintにパースはできないらしい。
			mode = temp_mode;
			Debug.Log(mode);

			reader.Close();
		}
	}


    void Start()
	{
		learning();
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
        controller.UpdateMeditationEvent += OnUpdateMeditation;
        controller.UpdateRawdataEvent += OnUpdateRawdata;

        controller.UpdateDeltaEvent += OnUpdateDelta;

		controller.UpdateBlinkEvent += OnUpdateBlink;


        controller.UpdateThetaEvent      += OnUpdateTheta;
        controller.UpdateLowAlphaEvent   += OnUpdateLowAlpha;
        controller.UpdateHighAlphaEvent  += OnUpdateHighAlpha;
        controller.UpdateLowBetaEvent    += OnUpdateLowBeta;
        controller.UpdateHighBetaEvent   += OnUpdateHighBeta;
        controller.UpdateLowGammaEvent   += OnUpdateLowGamma;
        controller.UpdateHighGammaEvent  += OnUpdateHighGamma;
        
		//�����ɃR�l�N�V�������g���C����̂ŁA��ڑ��̏ꍇ������R�����g�A�E�g
		//try�ɂ��Ă����Ŗ����Ƀ��[�v���邩��_��������
		//controller.Connect();
        counter = 0;
		counter2 = 0;
		attack_counter = 0;
    }

	void OnUpdateBlink(int value)
	{
		blink1 = value;
	}

	void OnUpdatePoorSignal(int value) {
		poorSignal1 = value;
		if (value < 25) {
			indexSignalIcons = 0;
		} else if (value >= 25 && value < 51) {
			indexSignalIcons = 4;
		} else if (value >= 51 && value < 78) {
			indexSignalIcons = 3;
		} else if (value >= 78 && value < 107) {
			indexSignalIcons = 2;
		} else if (value >= 107) {
			indexSignalIcons = 1;
		}
	}
	void OnUpdateAttention(int value) {
		attention1 = value;
	}
	void OnUpdateMeditation(int value) {
		meditation1 = value;
	}
	void OnUpdateDelta(float value) {
		delta = value;
	}

    void OnUpdateTheta(float value)
    {
        Theta = value;
    }
    void OnUpdateLowAlpha(float value)
    {
        LowAlpha = value;
    }
    void OnUpdateHighAlpha(float value)
    {
        HighAlpha = value;
    }
    void OnUpdateLowBeta(float value)
    {
        LowBeta = value;
    }
    void OnUpdateHighBeta(float value)
    {
        HighBeta = value;
    }
    void OnUpdateLowGamma(float value)
    {
        LowGamma = value;
    }
    void OnUpdateHighGamma(float value)
    {
        HighGamma = value;
    }
    void OnUpdateRawdata(int value)
    {
        Rawdata = value;
    }

    void writedata()
    {	
        counter = (counter + 1) % 10;
        if (counter == 0)
        {
			Debug.Log("Write");
            using (var writer = new System.IO.StreamWriter("Brainwavelog.txt", true))
            {
                writer.Write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}\n", poorSignal1, blink1, attention1, meditation1, delta,  Rawdata, Theta, LowAlpha, HighAlpha, LowBeta, HighBeta, LowGamma, HighGamma);
            }
        }
    }

	void modeselector()
	{
		//������SVM�̔���@�ɂ���
		if (attention1 > 50)
		{
			mode = 1;
		}
		else if (meditation1 > 50)
		{
			mode = 2;
		}
		else
		{
			mode = 0;
		}
	}

    void OnGUI()
	{
		attack_counter--;
		attack_counter = attack_counter <0 ? 0 : attack_counter;

		if (blink1 >= 0)
		{
			blinkcounter++;
		}
		if (blinkcounter >= 60) {
			blinkcounter = 0;
			blink1 = 0;
		}


        //writedata();
		//modeselector();
		//learning();
	}
}
