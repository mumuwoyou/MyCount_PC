﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using log4net;
using System.Collections.Generic;
using System.Configuration;

namespace MyCount
{
    public partial class FormDataSelect : Form
    {
        /// <summary> 
        /// PAD 数据上传下载 
        /// </summary> 
        /// <param name="Tag">默认0：PAD-》PC，1：PC-》PAD</param> 
        public FormDataSelect(int Tag)
        {
            InitializeComponent();
            m_Tag = Tag;
            switch (m_Tag)
            {
                case 1:
                    btnDownload.Visible = false;
                    btnUpload.Visible = true;
                    break;
                default:
                    btnUpload.Visible = false;
                    btnDownload.Visible = true;
                    break;
            }

        }

        #region 成员变量 
        static ILog m_log = LogManager.GetLogger(typeof(FormDataSelect));
        /// <summary> 
        /// 判断当前是上传(0)，还是下载(1) 
        /// </summary> 
        int m_Tag = 0;

        /// <summary> 
        /// 当前pad存储的路径是内部存储设备 
        /// </summary> 
        bool IsSDCard = true;

        /// <summary> 
        /// pad端存储路径 
        /// </summary> 
        string strDataPath = "";

        /// <summary> 
        /// PC端存储路径 
        /// </summary> 
        string strPCFilePath = "";

        /// <summary> 
        /// 内置存储卡路径 
        /// </summary> 
        string sdCardPath = "";
        /// <summary> 
        /// 外接存储卡路径 
        /// </summary> 
        string extSdCardPath = "";

       
        #endregion

        #region 窗体事件 
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadConfig();
            strPCFilePath = mConfig[IndexOfPcPath];
            if (!string.IsNullOrEmpty(mConfig[IndexOfWaitTime]))
                nudWaitTime.Value = Convert.ToInt32(mConfig[IndexOfWaitTime]);

            //马上启动的话，减慢了界面打开速度。 
            //GetInfo(); 

            //从app.config文件获取路径   
            strDataPath = System.Configuration.ConfigurationManager.AppSettings["DataPath"];
            sdCardPath = "sdcard" + strDataPath;
            extSdCardPath = "storage/extSdCard" + strDataPath;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mConfig[IndexOfDevices] = Convert.ToString(cbbDevices.SelectedItem);

            mConfig[IndexOfPcPath] = Convert.ToString(strPCFilePath);
            mConfig[IndexOfWaitTime] = nudWaitTime.Value.ToString();


            SaveConfig();

            //自动清理adb进程	 
            try
            {
                var processess = Process.GetProcessesByName("adb");
                foreach (var process in processess)
                    if (process.StartInfo.FileName.Contains(Application.StartupPath))
                        process.Kill();
            }
            catch
            {
                //ignore all 
            }
        }

        private void cbbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceNo = Convert.ToString(cbbDevices.SelectedItem);
            txbDeviceInfo.Text = string.Format("{0} {1} {2}({3})"
                , AdbHelper.GetDeviceBrand(deviceNo)
                , AdbHelper.GetDeviceModel(deviceNo)
                , AdbHelper.GetDeviceVersionRelease(deviceNo)
                , AdbHelper.GetDeviceVersionSdk(deviceNo));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ProcessHelper.WaitTime = (int)nudWaitTime.Value;
        }
        /// <summary> 
        /// PAD -> PC 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void btnDownload_Click(object sender, EventArgs e)
        {
            
            /*if (!Directory.Exists(cbbPcPath.Text))
            {
                ShowInfo("Pc路径不存在！");
                return;
            }
            if (strDataPath == null || strDataPath.Equals(""))
            {
                ShowInfo("Pad数据路径未配置！请检查配置文件");
                return;
            }*/
            
            Cursor.Current = Cursors.WaitCursor;
            lblInfo.Text = null;
            lblInfo.Refresh();
            AdbHelper.SendBroadCastToDevice(Convert.ToString(cbbDevices.SelectedItem), "BROADCAST_ACTION_PC_PULLING");
            try
            {
                //string outPcPath = Tools.CombinePath(cbbPcPath.Text, "testdb.db");
                string outPcPath = "mycount.db";
                m_log.Info("PC下载路径：" + outPcPath);
                if (IsSDCard)//内置存储卡 
                {
                    if (AdbHelper.CopyFromDevice(Convert.ToString(cbbDevices.SelectedItem), sdCardPath, outPcPath))
                    {
                        ShowInfo("下载数据库执行成功。");
                        AdbHelper.SendBroadCastToDevice(Convert.ToString(cbbDevices.SelectedItem), "BROADCAST_ACTION_PC_PULLED");
                    }
                    else
                        ShowInfo("下载数据库执行失败！");
                }
                
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetInfo();
        }
        /// <summary> 
        /// PC->PAD EVENT 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void btnUpload_Click(object sender, EventArgs e)
        {
            //选择DB文件所在的文件夹，获取总的DB文件，推送到sd卡目录 

            Cursor.Current = Cursors.WaitCursor;
            ShowInfo(null);
            try
            {
                var devPath = IsSDCard ? sdCardPath : extSdCardPath;
                string dbPath = Tools.CombinePath(strPCFilePath, "mycount.db");
                //string picPath = UtilsString.CombinePath(strPCFilePath, "image"); 
                if (AdbHelper.CopyToDevice(Convert.ToString(cbbDevices.SelectedItem), dbPath, devPath))
                {
                    ShowInfo("数据库文件上传成功。");
                    AdbHelper.SendBroadCastToDevice(Convert.ToString(cbbDevices.SelectedItem), "BROADCAST_ACTION_PC_PUSHED");
                }
                else
                    ShowInfo("数据库文件上传失败！");
               
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region 成员函数 
        private void GetInfo()
        {
            btnDownload.Enabled = false;
            btnUpload.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            ShowInfo("获取信息中···");
            lsbFiles.DataSource = null;
            lsbFiles.Items.Clear();
            try
            {
                //启动服务 
                if (!AdbHelper.StartServer())
                {
                    ShowInfo("服务启动失败！");
                    return;
                }

                //获取设备列表 
                var devs = AdbHelper.GetDevices();
                if (devs.Length == 0)
                {
                    ShowInfo("没有连接设备！");
                    return;
                }
                if (txbDeviceInfo.Text.Contains("error: device offline"))
                {
                    ShowInfo("设备连接失败，请重新拔插USB线！");
                    return;
                }

                cbbDevices.Items.Clear();
                cbbDevices.Items.AddRange(devs);
                cbbDevices.SelectedIndex = 0;
                if (m_Tag == 0)//PAD下载数据，展示设备数据 
                {
                    //遍历指定目录:首先遍历内置内存卡，然后是外接卡 
                    /*var dataFolderList = AdbHelper.ListDataFolder(Convert.ToString(cbbDevices.SelectedItem), sdCardPath);

                    m_log.Info("内存卡路径：" + sdCardPath);
                    m_log.Info("内存卡数据条数：" + dataFolderList.Count);
                    
                    if (dataFolderList.Count == 0)
                    {
                        dataFolderList = AdbHelper.ListDataFolder(Convert.ToString(cbbDevices.SelectedItem), extSdCardPath);
                        m_log.Info("外接卡路径：" + extSdCardPath);
                        m_log.Info("外接卡数据条数：" + dataFolderList.Count);
                        if (dataFolderList.Count == 0)
                        {
                            ShowInfo("遍历数据目录失败！");
                        }
                        IsSDCard = false;
                        return;
                    }
                    

                    //反转顺序，将系统的报名排到最后面 
                    dataFolderList.Reverse();

                    lsbFiles.DataSource = dataFolderList;*/
                    lsbFiles.Items.Add(sdCardPath);
                }
                else//PC上传数据，展示pc数据 
                {
                    lsbFiles.Items.Clear();
                    //string dbPath = Tools.CombinePath(strPCFilePath, "testdb.db");
                    string dbPath = "mycount.db";
                    if (Tools.FileExist(dbPath))
                    {
                        lsbFiles.Items.Add(dbPath);
                    }
                   
                }
                ShowInfo("信息获取完毕。");

                cbbDevices.SelectedItem = mConfig[IndexOfDevices];
                if (m_Tag == 0)
                {
                    btnDownload.Enabled = true;
                }
                else
                {
                    btnUpload.Enabled = true;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ShowInfo(string info)
        {
            lblInfo.Text = info;
            lblInfo.Refresh();
        }
        #endregion

        #region 设置相关 
        private const int IndexOfDevices = 0;
        private const int IndexOfPcPath = 3;
        private const int IndexOfWaitTime = 4;
        private string[] mConfig = new[] { "", "", "", "", "", "" };
        private readonly string mConfigPath = Path.Combine(Application.StartupPath, "adb.ini");

        private void ReadConfig()
        {
            if (!File.Exists(mConfigPath))
                return;
            mConfig = File.ReadAllLines(mConfigPath);

            if (mConfig == null || mConfig.Length != 6)
                mConfig = new[] { "", "", "", "", "", "" };
        }
        private void SaveConfig()
        {
            File.WriteAllLines(mConfigPath, mConfig);
        }
        #endregion


    }
}
