using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using rfid;

namespace AnimalCS
{
    public partial class Form1 : Form
    {
        int TTYP;
        System.Collections.ArrayList list = new ArrayList();
        int count = 0;
        int flashed = 0;
        String str2Flash = "";

        RadioButton rb_HDX;
        RadioButton rb_FDXHitag;
        RadioButton rb_FDXEm;
        BackgroundWorker m_oWorker;


        static string MakeStringFromArray(sbyte[] Arr, int StringNummer)
        {
            string strLine;
            strLine = "";

            int i = 0;
            for (int aktStringNummer = 0; aktStringNummer <= StringNummer; aktStringNummer++)
            {
                strLine = "";
                for (; (i < Arr.Length); i++)
                {
                    if (Arr[i] == 0)
                    {
                        break;
                    }
                    strLine += (char)Arr[i];
                }
                i++;
                if (strLine.Length == 0)
                    break;
            }
            return strLine;
        }

        static sbyte[] MakeArrayFromString(string Name)
        {
            sbyte[] arr = new sbyte[Name.Length];
            for (int i = 0; i < Name.Length; i++)
                arr[i] = (sbyte)Name[i];
            return arr;
        }

        static void CopyArrayTo(SByte[] Src, int SrcOffset, SByte[] Dest, int DestOffset, int Len)
        {
            while (Len > 0)
            {
                Dest[DestOffset++] = Src[SrcOffset++];
                Len--;
            }
        }

        static Int64 BufferToInt64(byte[] Arr)
        {
            Int64 Result = 0;
            for (int i = Arr.Length - 1; i >= 0; i--)
            {
                Result <<= 8;
                Result += Arr[i];
            }
            return Result;
        }

        static byte[] Int64ToBuffer(Int64 Value)
        {
            byte[] Buffer = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                Buffer[i] = (byte)(Value & 0x00FF);
                Value >>= 8;
            }
            return Buffer;
        }

        static bool IsNumber(string value)
        {
            if (value.Length == 0)
                return false;

            for (int i = 0; i < value.Length; i++)
                if (!Char.IsDigit(value[i]))
                    return false;

            return true;
        }
        static bool IsAnimalHDXProgrammer(sbyte[] Version)
        {
            // All new device types with first two digits of Device Number at least 24 and third digit at least 4 support HDX programmer mode
            if ((Version[0] >= '2') && (Version[1] >= '4'))
                return (Version[2] >= '4') ? true : false;

            // All former device types do not support HDX
            return false;
        }

        int PortHandle;

        public Form1()
        {
            InitializeComponent();

            btnStart.Enabled = false;
            btnStop.Enabled = false;

            m_oWorker = new BackgroundWorker();

            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;

            int MaxLen = 255;
            int ListLen = 0;
            int DevListLen;

            SByte[] NamenListe = new SByte[1000];
            SByte[] DevList = new SByte[MaxLen];

            DevListLen = GIS_LF_API.TSLF_GetUSBDeviceNames(DevList, MaxLen) - 1;
            CopyArrayTo(DevList, 0, NamenListe, ListLen, DevListLen);
            ListLen += DevListLen;
            DevListLen = GIS_LF_API.TSLF_GetLanDeviceNames(DevList, MaxLen) - 1;
            CopyArrayTo(DevList, 0, NamenListe, ListLen, DevListLen);
            ListLen += DevListLen;
            DevListLen = GIS_LF_API.TSLF_GetCOMDeviceNames(DevList, MaxLen) - 1;
            CopyArrayTo(DevList, 0, NamenListe, ListLen, DevListLen);
            ListLen += DevListLen;
            ListLen++;

            if (ListLen > 1)
            {
                string DeviceName;
                // Use first Device in List
                DeviceName = MakeStringFromArray(NamenListe, 0);

                PortHandle = GIS_LF_API.TSLF_Open(MakeArrayFromString(DeviceName), 19200, 0, 500);
                if (GIS_LF_API.TSLF_IsProgrammer(PortHandle) != 1)
                {
                    MessageBox.Show("Device is no Programmer");
                    GIS_LF_API.TSLF_Close(PortHandle);
                    PortHandle = 0;
                }
                else
                {
                    // Get device version from device, to cehck if read device is connected.
                    // The first 3 digits of the string give the device number
                    // valid device number is 039 for TS-W34AC, 244 for TS-RW38AC
                    sbyte[] Version = new sbyte[4];
                    sbyte[] InternalDeviceName = new sbyte[32];
                    int nReturn = GIS_LF_API.TSLF_GetDeviceVersion(PortHandle, Version, 4, InternalDeviceName, 32);
                    if (nReturn == -1)
                    {
                        int Error = GIS_LF_API.TSLF_GetLastError(PortHandle);
                        MessageBox.Show("DeviceVersion can not be read");
                        GIS_LF_API.TSLF_Close(PortHandle);
                        PortHandle = 0;
                    }
                    else
                    {
                        if (IsAnimalHDXProgrammer(Version))
                        {
                            // Device is valid
                        }
                        else
                        {
                            // Invalid device, will be closed
                            MessageBox.Show("Connected device is no Animal programmer!");
                            GIS_LF_API.TSLF_Close(PortHandle);
                            PortHandle = 0;
                        }
                    }
                }
            }
            else
            {
                PortHandle = 0;
            }

            if (PortHandle <= 0)
            {
                MessageBox.Show("Device could not be opened");
            }
            else
            {
                // Turn off Antenna
                GIS_LF_API.TSLF_SetRF(PortHandle, 0);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (PortHandle > 0)
                GIS_LF_API.TSLF_Close(PortHandle);

            if (m_oWorker.IsBusy)
            {
                // Notify the worker thread that a cancel has been requested.
                // The cancel will not actually happen until the thread in the
                // DoWork checks the m_oWorker.CancellationPending flag. 
                m_oWorker.CancelAsync();
            }
            //Close();
        }

        void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            RadioButton rbHDX = (RadioButton)this.rbHDX;
            RadioButton rbFDXHitag = (RadioButton)this.rbFDXHitag;
            RadioButton rbFDXEm = (RadioButton)this.rbFDXEm;

            rbHDX.Checked = false;
            rbFDXHitag.Checked = false;
            rbFDXEm.Checked = false;

            // Validate the current page. To cancel the select, use:
            // e.Cancel = true;
        }


        /// <summary>
        /// Notification is performed here to the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This function fires on the UI thread so it's safe to edit
            // the UI control directly, no funny business with Control.Invoke :)
            // Update the progressBar with the integer supplied to us from the
            // ReportProgress() function.  
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
            lblScritture.Text = "" + flashed;
            if(e.ProgressPercentage>0)
                trspScritto.Text = "" + list[flashed-1];

        }

        /// <summary>
        /// On completed do the appropriate task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                //Il programma deve essere chiuso. Il codificatore non avvia una nuova sessione.
                lblStatus.Text = "Task Cancelled.";
                btnStop.Enabled = false;
                btnCaricaFile.Enabled = false;
                fileName.Enabled = false;
            }
            // Check to see if an error occurred in the background process.
            else if (e.Error != null)
            {
                lblStatus.Text = "Error while performing background operation.";
                btnStart.Enabled = false;
                btnCaricaFile.Enabled = true;
                fileName.Enabled = true;
            }
            else
            {
                // Everything completed normally.
                lblStatus.Text = "Task Completed!";
                btnStop.Enabled = false;
                btnCaricaFile.Enabled = false;
                fileName.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Change the status of the buttons on the UI accordingly
            //The start button is disabled as soon as the background operation is started
            //The Cancel button is enabled so that the user can stop the operation 
            //at any point of time during the execution
            // Kickoff the worker thread to begin it's DoWork function.
            if (rb_FDXEm.Checked == true || rb_FDXHitag.Checked == true || rb_HDX.Checked == true)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnCaricaFile.Enabled = false;
                fileName.Enabled = false;
                flashed = 0;

                m_oWorker.RunWorkerAsync();
            }

            else
                MessageBox.Show("Enter transpoder type");
        }


        /// <summary>
        /// Time consuming operations go here </br>
        /// i.e. Database operations,Reporting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // The sender is the BackgroundWorker object we need it to
            // report progress and check for cancellation.
            //NOTE : Never play with the UI thread here...

            int st = 0;

            if (rb_HDX.Checked == true)
            {
                TTYP = GIS_LF_API.TTYP_HDX_PLUS;
                st = elaborateHDX();

            }
            else if (rb_FDXHitag.Checked == true)
            {
                TTYP = GIS_LF_API.TTYP_HITAG_Y;
                st = elaborateFDX();
            }
            else if (rb_FDXEm.Checked == true)
            {
                TTYP = GIS_LF_API.TTYP_EM4305;
                st = elaborateFDX();
            }

            if (st < 0)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was cancelled.
                e.Cancel = true;
                m_oWorker.ReportProgress(0);
                return;
            }
        }

        private int elaborateHDX()
        {
            // Turn on Antenna
            GIS_LF_API.TSLF_SetRF(PortHandle, 1);
            int factor = 100 / list.Count;
            while (flashed < list.Count)
            {
                m_oWorker.ReportProgress(flashed * factor);
                if (m_oWorker.CancellationPending)
                {
                    return -1;
                }
                //CAMBIARE IN readFDX < 0 IN FASE DI PRODUZIONE!!!!!
                if (GIS_LF_API.TSLF_GetTagType(PortHandle, TTYP) > 0 && readHDX() < 0)
                {
                    writeHDX((String)list[flashed]);
                }
                System.Threading.Thread.Sleep(3000);
            }
            // Turn off Antenna
            GIS_LF_API.TSLF_SetRF(PortHandle, 0);
            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
            return 1;
        }

        private int elaborateFDX()
        {
            // Turn on Antenna
            GIS_LF_API.TSLF_SetRF(PortHandle, 1);
            int factor = 100 / list.Count;
            while (flashed < list.Count)
            {
                m_oWorker.ReportProgress(flashed * factor);
                if (m_oWorker.CancellationPending)
                {
                    return -1;
                }
                //CAMBIARE IN readFDX < 0 IN FASE DI PRODUZIONE!!!!!
                if (GIS_LF_API.TSLF_GetTagType(PortHandle, TTYP) > 0 && readFDX() < 0)
                {
                    writeFDX((String)list[flashed]);
                }
                System.Threading.Thread.Sleep(3000);
            }
            // Turn off Antenna
            GIS_LF_API.TSLF_SetRF(PortHandle, 0);
            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
            return 1;
        }

        private int readHDX()
        {
            if (PortHandle > 0)
            {
                int Country;
                Byte[] Buffer = new Byte[8];
                int AnimalFlag;
                int DatenblockFlag;
                int Reserved;
                int Extension;
                return GIS_LF_API.TSLF_Read_HDX(PortHandle, out Country, Buffer, 8, out AnimalFlag, out DatenblockFlag, out Reserved, out Extension);
            }
            else
            {
                MessageBox.Show("No Device attached");
                return -1;
            }
        }

        private int readFDX()
        {
            if (PortHandle > 0)
            {
                int Country;
                Byte[] Buffer = new Byte[8];
                int AnimalFlag;
                int DatenblockFlag;
                int Reserved;
                int Extension;
                return GIS_LF_API.TSLF_Read_FDXB(PortHandle, out Country, Buffer, 8, out AnimalFlag, out DatenblockFlag, out Reserved, out Extension);
            }
            else
            {
                MessageBox.Show("No Device attached");
                return -1;
            }
        }

        private void writeHDX(String str)
        {
            if (PortHandle > 0)
            {
                String identNr = str.Substring(4, 12);
                String countryCode = str.Substring(0, 4);
                Byte[] FactoryID = new Byte[8];
                if (IsNumber(identNr))
                {
                    Byte[] Buffer = Int64ToBuffer(Convert.ToInt64(identNr));

                    int Country = 0;
                    if (IsNumber(countryCode))
                        Country = Convert.ToInt32(countryCode);
                    else
                        MessageBox.Show("Enter corret CountryCode");

                    FactoryID[0] = 0;
                    FactoryID[1] = 0;
                    FactoryID[2] = 0;
                    FactoryID[3] = 0;
                    FactoryID[4] = 0;
                    FactoryID[5] = 0;
                    FactoryID[6] = 0;
                    FactoryID[7] = 0;

                    if (GIS_LF_API.TSLF_Write_HDX(PortHandle, TTYP, FactoryID, Country, Buffer, 8, 1, 0, 0, 0, 0) < 0)
                    {
                        MessageBox.Show("Write Error - " + countryCode + "" + identNr);
                    }
                    else
                    {
                        flashed++;
                    }
                }
                else
                {
                    MessageBox.Show("Enter Ident Nr. (only Digits allowed)");
                }
            }
            else
            {
                MessageBox.Show("No Device attached");
            }
        }

        private void writeFDX(String str)
        {
            if (PortHandle > 0)
            {
                String identNr = str.Substring(4, 12);
                String countryCode = str.Substring(0, 4);
                Byte[] FactoryID = new Byte[8];
                if (IsNumber(identNr))
                {
                    Byte[] Buffer = Int64ToBuffer(Convert.ToInt64(identNr));

                    int Country = 0;
                    if (IsNumber(countryCode))
                        Country = Convert.ToInt32(countryCode);
                    else
                        MessageBox.Show("Enter corret CountryCode");

                    Console.WriteLine(Country);
                    Console.WriteLine(BufferToInt64(Buffer).ToString());

                    FactoryID[0] = 0;
                    FactoryID[1] = 0;
                    FactoryID[2] = 0;
                    FactoryID[3] = 0;
                    FactoryID[4] = 0;
                    FactoryID[5] = 0;
                    FactoryID[6] = 0;
                    FactoryID[7] = 0;

                    if (GIS_LF_API.TSLF_Write_FDXB(PortHandle, TTYP, FactoryID, Country, Buffer, 8, 1, 0, 0, 0, 0) < 0)
                    {
                        MessageBox.Show("Write Error - " + countryCode + "" + identNr);
                    }
                    else
                    {
                        flashed++;
                    }
                }
                else
                {
                    MessageBox.Show("Enter Ident Nr. (only Digits allowed)");
                }
            }
            else
            {
                MessageBox.Show("No Device attached");
            }
        }

        private void btnCaricaFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName.Text = openFileDialog1.FileName;
                string[] lines = System.IO.File.ReadAllLines(@openFileDialog1.FileName);

                list = new ArrayList();
                foreach (string line in lines)
                {
                    //non considerare le linee vuote (esempio ultima riga di ritorno a capo)
                    if(!line.Equals(""))
                        list.Add(line);
                }
                lblRigheFile.Text = "" + list.Count;
                //Verificare il tipo di transponder TTYP 
                rb_HDX = (RadioButton)this.rbHDX;
                rb_FDXHitag = (RadioButton)this.rbFDXHitag;
                rb_FDXEm = (RadioButton)this.rbFDXEm;

                btnStart.Enabled = true;

            }
        }
    }
}
