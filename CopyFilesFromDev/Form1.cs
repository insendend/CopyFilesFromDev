using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// Написать программу, которая при подключении нового диска осуществляет поиск всех файлов и 
// копирование к себе в созданный каталог, имя которого должно соответствовать метке подключенного диска.

namespace CopyFilesFromDev
{
    // делегат под сбор информации по флешке
    delegate Dictionary <string, int> DelStat();

    // делегат копирования
    delegate List <string> DelCopy(string pattern);

    public partial class Form1 : Form
    {
        // список подключенных дисков
        private List<DriveInfo> lstDrives = null;
        
        // ID сообщ. добавл. диска
        private const int ADD_DEVICE    = 0x8000;

        // ID сообщ. удаления. диска
        private const int REM_DEVICE    = 0x8004;

        // время запуска программы
        private readonly DateTime dtFirst = DateTime.Now;

        // метка тома (диска)
        private string strAddedDiskName = null;
        private string strVolumeLabel = null;

        public Form1()
        {          
            InitializeComponent();

            // получаем список доступных дисков
            this.lstDrives = new List<DriveInfo>(DriveInfo.GetDrives());

            this.l_timecaption.Text = "Время работы программы: ";
            this.l_time.Text = new TimeSpan().ToString();
            this.l_count.Text = null;
            this.l_attachinfo.Text = "Ожидание подключения диска...";
            this.l_helpinfo.Text = null;
            this.l_timerinfo1.Text = null;
            this.l_timerinfo2.Text = null;
            this.but_copy.Text = "Копировать";
        }

        // ловим сообщение от ОС
        protected override void WndProc(ref Message msg)
        {
            if ((int)msg.WParam == ADD_DEVICE)
            {
                // был подключен диск
                this.InitAddedDisk();

                this.l_attachinfo.Text = string.Format("Подключён диск: {0}", this.strAddedDiskName);
                this.timer_timeleft.Enabled = true;

                if (this.strAddedDiskName != null)
                {
                    // настраиваем методы
                    DelStat ds = ShowInfo;

                    this.lb_foundfiles.Visible = true;

                    // вывод информации о подключённом диске
                    ds.BeginInvoke(Finish, ds);
                }
            }
            // проверяем на отключение диска
            else if ((int)msg.WParam == REM_DEVICE)
            {
                // получаем заново список дисков
                List<DriveInfo> lstTmp = new List<DriveInfo>(DriveInfo.GetDrives());

                // сверяем с ранее полученным списком дисков
                foreach (var i in lstDrives)

                    // проверяем на содержание нового списка дисков со старым
                    if (!lstTmp.Exists(x => i.Name == x.Name))
                    {
                        lstDrives.Remove(i);
                        break;
                    }
            }

                base.WndProc(ref msg);
        }

        // поиск добавленного диска
        private void InitAddedDisk()
        {
            try
            {
                // получаем заново список дисков
                List<DriveInfo> lstTmp = new List<DriveInfo>(DriveInfo.GetDrives());

                // сверяем с ранее полученным списком дисков
                foreach (var i in lstTmp)

                    // проверяем на содержание нового списка дисков со старым
                    if (!this.lstDrives.Exists(x => x.Name == i.Name))
                    {
                        // определяем добавленный диск
                        this.strAddedDiskName = i.Name;

                        // метка тома
                        this.strVolumeLabel = i.VolumeLabel;

                        this.lstDrives.Add(i);
                        break;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // метод копирования файлов
        private List <string> CopyOnlyParam(string ext)
        {
            var files = new List<string>();

            try
            {
                // рекурсивный поиск по всем каталогам файлов с расширением из параметров
                files = this.GetFiles(this.strAddedDiskName, ext);

                if (files.Count > 0)
                {
                    // каталог с запущенной программой
                    string rootFolder = Directory.GetCurrentDirectory();

                    // имя компьютера, где была зарущена программа
                    string namePC = Environment.MachineName;

                    // перебираем все найденные TXT-файлы
                    foreach (var sourcePath in files)
                    {
                        // формируем полный путь и имя файла назначения 
                        string destPath = Path.Combine(Path.Combine(rootFolder, namePC), sourcePath.Remove(0, 2).Insert(0, this.strVolumeLabel));

                        // создаем каталог, куда будем копировать файл
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // копирование
                        File.Copy(sourcePath, destPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return files;
        }


        // рекурсивный поиск файлов, который игнорит системные файлы
        private List <string> GetFiles(string path, string pattern)
        {
            var files = new List<string>();

            try
            {
                // файлы из родительской папки
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));

                // добавляем файлы из каждой внутренней папки
                foreach (var directory in Directory.GetDirectories(path))
                    files.AddRange(GetFiles(directory, pattern));
            }
            catch (UnauthorizedAccessException) { }

            // возвращаем сформированный список файлов
            return files;
        }



        // вывод списка расширений файлов из подключенного диска
        private Dictionary <string, int> ShowInfo()
        {
            // коллекция для хранения расширений и их кол-ва
            var dic = new Dictionary<string, int>();

            try
            {
                // все файлы с полными путями
                List <string> allFiles = this.GetFiles(this.strAddedDiskName, "*.*");

                if (allFiles.Count > 0)
                {
                    // перебираем все файлы
                    foreach (var fileName in allFiles)
                    {
                        // расширение файла
                        string strExt = Path.GetExtension(fileName).ToUpper();

                        // формируем словарь
                        if (string.IsNullOrEmpty(strExt))
                        {
                            // метка "без расширения"
                            string strKey = "Без расширения";

                            // добавляем в словарь
                            if (!dic.ContainsKey(strKey))
                                dic.Add(strKey, 1);
                            else
                                dic[strKey]++;
                        }
                        else
                        {
                            // добавляем в словарь остальные расширения
                            if (!dic.ContainsKey(strExt))
                                dic.Add(strExt, 1);
                            else
                                dic[strExt]++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dic;
        }

        // работа таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            // выводим время работы программы в label
            this.l_time.Text = (DateTime.Now - this.dtFirst.TimeOfDay).ToLongTimeString();
        }

        // завершение асинхронного вызова
        private void Finish(IAsyncResult result)
        {
            try
            {
                DelStat ds = (DelStat)result.AsyncState;

                // возвращаем результат - словарь найденных типов файлов
                var dic = ds.EndInvoke(result);

                // кол-во файлов
                Action <string> act = (string s) => this.l_attachinfo.Text+= s;
                this.Invoke(act, string.Format("\nОбнаружено {0} файлов", dic.Sum(x => x.Value)));

                // помещаем словарь в листбокс
                Action <string> act2 = (string s) => this.lb_foundfiles.Items.Add(s);

                foreach (var ext in dic)
                    this.Invoke(act2, string.Format("{0}-файлов: {1}", ext.Key, ext.Value));

                Action <string> act3 = (string s) => this.l_helpinfo.Text = s;
                this.Invoke(act3, "Выбирите тип файлов для копирования из списка выше и нажмите \"Копировать\"");

                Action <bool> act4 = (bool b) => this.but_copy.Visible = b;
                this.Invoke(act4, true);

                Action<bool> act5 = (bool b) => this.lb_foundfiles.Visible = b;
                this.Invoke(act4, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);       
            }
        }

        // завершение асинхронного вызова
        private void Finish2(IAsyncResult result)
        {
            try
            {
                DelCopy dc = (DelCopy)result.AsyncState;

                // возвращаем результат - список скопированных файлов
                var files = dc.EndInvoke(result);

                // помещаем имена скопированных файлов в листбокс
                Action <List <string>> act1 = (List <string> lst) => this.lb_copiedfiles.Items.AddRange(lst.ToArray());
                this.Invoke(act1, files);

                // кол-во файлов
                Action <string> act2 = (string s) => this.l_count.Text = s;
                this.Invoke(act2, string.Format("Скопировано {0} файлов", files.Count));


                // помещаем скопированные файлы в листбокс
                Action <bool> act3 = (bool b) => this.lb_copiedfiles.Visible = b;
                this.Invoke(act3, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // автоматическое копирование при бездействии
        private int iSec = 10;
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.l_timerinfo1.Text = string.Format("Автоматическое копирование TXT-файлов начнется через {0}",--iSec);
            this.l_timerinfo2.Text = "*чтобы отменить, кликнете по окну";

            if (iSec == 0)
            {
                // имитируем клик по окну, чтобы остановить таймер и убрать текст
                this.Form1_MouseClick(null, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));

                // настраиваем делегат на метод
                DelCopy dc = CopyOnlyParam;
               
                // запускаем копирование
                IAsyncResult res = dc.BeginInvoke("*.txt", Finish2, dc);
            } 
        }

        // кнопка "Копировать"
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.lb_foundfiles.SelectedIndex == -1)
                MessageBox.Show("Вы не выбрали ни один тип файлов для копирования");
            else
            {
                // выделенный эл-т листбокса
                string strTmp = (string)this.lb_foundfiles.Items[this.lb_foundfiles.SelectedIndex];

                // выбирем из него расширение 
                string strExtstrTmp = strTmp.Substring(strTmp.IndexOf('.'), strTmp.IndexOf('-') - strTmp.IndexOf('.')).Insert(0,"*").ToLower();

                // настраиваем делегат на метод
                DelCopy dc = CopyOnlyParam;

                // запускаем копирование
                IAsyncResult res = dc.BeginInvoke(strExtstrTmp, Finish2, dc);
            }
        }

        // событие по нажатию на форму 
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // прервать таймер
            this.timer_timeleft.Enabled = false;

            this.l_timerinfo1.Text = null;
            this.l_timerinfo2.Text = null;
        }
    }
}     