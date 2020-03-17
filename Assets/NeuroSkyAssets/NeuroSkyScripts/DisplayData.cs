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

	public int mode;//none:0, 1:attack,2:defence


	void learning()
	{
		//var reader;
		try
		{
			var reader = new System.IO.StreamReader("result.txt", true);
			Debug.Log(reader);
			//while (!reader.EndOfStream)
			//{
				string line = reader.ReadLine();
				string[] values = line.Split(',');
				int temp_mode = int.Parse(values[0]);
				mode = temp_mode;
				Debug.Log(mode);
			//}
		}
		catch
		{
			Debug.Log("error");
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
        counter = (counter + 1) % 2;
        if (counter == 0)
        {
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
		//GUILayout.BeginHorizontal();


		//if (GUILayout.Button("Connect"))
		//{
		//	controller.Connect();
		//}
		//if (GUILayout.Button("DisConnect"))
		//{
		//	controller.Disconnect();
		//	indexSignalIcons = 1;
		//}
		//Debug.Log(indexSignalIcons);
		//Debug.Log(signalIcons[0]);
		//GUILayout.Space(Screen.width - 250);
		//GUILayout.Label(signalIcons[indexSignalIcons]);
		//GUILayout.Label("Test");

		//GUILayout.EndHorizontal();


		//GUILayout.Label("PoorSignal1:" + poorSignal1);
		//GUILayout.Label("Attention1:" + attention1);
		//GUILayout.Label("Meditation1:" + meditation1);
		//GUILayout.Label("Delta:" + delta);
		//GUILayout.Label("Blink:" + blink1);

		if (blink1 >= 0)
		{
			blinkcounter++;
		}
		if (blinkcounter >= 60) {
			blinkcounter = 0;
			blink1 = 0;
		}
        writedata();
		//modeselector();
		learning();
	}
}
