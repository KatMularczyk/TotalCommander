using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace TotalCommander
{
    public partial class Form1 : Form
    {
        Forwarder fw = new Forwarder();
        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_VOLUME = 0x00000002;
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);//obsługa pendrive'a 
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            DriveInfo[] allDrives = DriveInfo.GetDrives();
                            comboBox1.Items.Clear();
                            comboBox2.Items.Clear();
                            foreach (DriveInfo d in allDrives)
                            {
                                comboBox1.Items.Add(d.Name);
                                comboBox2.Items.Add(d.Name);
                            }
                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            allDrives = DriveInfo.GetDrives();
                            comboBox1.Items.Clear();
                            comboBox2.Items.Clear();
                            foreach (DriveInfo d in allDrives)
                            {
                                comboBox1.Items.Add(d.Name);
                                comboBox2.Items.Add(d.Name);
                            }
                            break;
                    }
                    break;
            }
        }
        public Form1()
        {
            InitializeComponent();
            DriveInfo[] allDrives = DriveInfo.GetDrives();//pobranie dysków

            foreach (DriveInfo d in allDrives)
            {
                comboBox1.Items.Add(d.Name);//dyski do comboboxów
                comboBox2.Items.Add(d.Name);
            }
      
        }
        private FileInfo[] getFilesList(string directory)//zwraca listę plików
        {
            DirectoryInfo fi = new DirectoryInfo(directory);
            FileInfo[] foundFiles = fi.GetFiles();
            return foundFiles;
          
        }

        private DirectoryInfo[] getDirsList(string directory)//zwraca listę folderów
        {
             DirectoryInfo di = new DirectoryInfo(directory);

            DirectoryInfo[] foundDirectories = di.GetDirectories();//System.UnauthorizedAccessException: „Odmowa dostępu do ścieżki „C:\Users\All Users\Pulpit”.”

             return foundDirectories;
          
        }

        private void updateFiles(FileInfo[] fileList, ListView toUpdate)//wypełnia listview danymi plików z listy
        {
            foreach (FileInfo f in fileList)
            {
                ListViewItem item = new ListViewItem(f.Name);
                item.SubItems.Add(f.CreationTime.ToString());
                toUpdate.Items.Add(item);
            }
        }

        private void updateDirs(DirectoryInfo[] dirsList, ListView toUpdate)//wypełnia listview danymi folderów z listy
        {
            foreach (DirectoryInfo d in dirsList)
            {
                ListViewItem item = new ListViewItem(d.Name);
                item.SubItems.Add(d.CreationTime.ToString());
                toUpdate.Items.Add(item);
            }
        }

        
        private string listUpdate(ListView toUpdate, string forwardersDir)// update listview
        {
            string selItem = toUpdate.SelectedItems[0].Text.ToString();//wybrany folder
            string tempcurDir= forwardersDir + "\\" + selItem;
            string curDir = forwardersDir; 
           
            if (selItem == "[..]")//update curdir jeśli powrót do wyższego folderu
            {
                int index = forwardersDir.LastIndexOf("\\");
                if (index >= 0)
                    tempcurDir = forwardersDir.Substring(0, index);
                if(tempcurDir[(tempcurDir.Count())-1]==':')
                    tempcurDir = tempcurDir+'\\';

            }

            try
            {
                FileAttributes attr = File.GetAttributes(tempcurDir);
                if (!attr.HasFlag(FileAttributes.Directory))// jeśli nastąpi próba otwarcia pliku
                {
                    MessageBox.Show("That's a file!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempcurDir = curDir;
                }
                DirectoryInfo test = new DirectoryInfo(tempcurDir);
                DirectoryInfo[] foundDirectories = test.GetDirectories();
                
            }
            catch (System.IO.DirectoryNotFoundException)//obsługa wyjątku: nie znaleziono ścieżki
            {
                MessageBox.Show("Directory not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toUpdate.Clear();
                tempcurDir = null;
            }
            catch (System.IO.FileNotFoundException)//obsługa wyjątku: nie znaleziono ścieżki
            {
                MessageBox.Show("Directory not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toUpdate.Clear();
                tempcurDir = null;
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tempcurDir = curDir;
            }
            curDir = tempcurDir;

                    toUpdate.Items.Clear();
                    ListViewItem item = new ListViewItem("[..]");
                    item.SubItems.Add(DateTime.Now.ToString());
                    toUpdate.Items.Add(item); 
                    updateDirs(getDirsList(curDir), toUpdate);
                    updateFiles(getFilesList(curDir), toUpdate);
            
                return curDir;//dla updatu zmiennych pośredniczących
        }

        private void deleteDir(ListView list, string forwardersDir)
        {
            DialogResult shouldDelete = MessageBox.Show("Delete directory?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (shouldDelete == DialogResult.Yes)
            {
                string selItem = list.SelectedItems[0].Text.ToString();//wybrany folder
                string toDel = forwardersDir + "\\" + selItem;
                DirectoryInfo toDelete = new DirectoryInfo(@toDel);
                try
                {
                    toDelete.Delete();
                    list.Items.Remove(list.SelectedItems[0]);
                }
                catch (IOException)
                {
                    DialogResult diaRes = MessageBox.Show("That directory is not empty! Delete anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (diaRes == DialogResult.Yes)
                    {
                        toDelete.Delete(true);
                        list.Items.Remove(list.SelectedItems[0]);
                    }

                }
            }

        }


        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonCreate = new Button();
            Button buttonCancel = new Button();
            form.Text = "Creating new directory";
            label.Text = "Pass the new directory name";
            buttonCreate.Text = "Create";
            buttonCancel.Text = "Cancel";
            buttonCreate.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(6, 6, 2, 3);
            textBox.SetBounds(16, 26, 107, 4);
            buttonCreate.SetBounds(26, 56, 50, 20);
            buttonCancel.SetBounds(100, 56, 50, 20);
            label.AutoSize = true;
            form.ClientSize = new Size(200, 100);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { label, textBox, buttonCreate, buttonCancel });
            form.AcceptButton = buttonCreate;
            form.CancelButton = buttonCancel;
            DialogResult diaRes = form.ShowDialog();
            value = textBox.Text;
            return diaRes;
        }

        private void createDir(ListView list, string forwardersDir)
        {
            string value = "";
            if (InputBox("Creating new directory", "Pass the new directory name", ref value) == DialogResult.OK)
            {
                string toCreate = forwardersDir + "\\" + value;
                if (!Directory.Exists(toCreate))
                {
                    ListViewItem item = new ListViewItem(value);
                    item.SubItems.Add(DateTime.Now.ToString());
                    list.Items.Add(item);
                    DirectoryInfo di1 = new DirectoryInfo(@toCreate);
                    di1.Create();
                }
                else
                {
                    MessageBox.Show("Directory already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void copyByDrop(ListView sourceList, ListView destList, string sourceForw, string destForw, ListViewItem toDrop)
        {
            try
            {               
                string dir = toDrop.Text;
                string source = sourceForw + "\\" + dir;
                string dest = destForw + "\\" + dir;
                FileAttributes attr = File.GetAttributes(source);
                if (!attr.HasFlag(FileAttributes.Directory))// jeśli nastąpi próba otwarcia pliku
                    FileSystem.CopyFile(source, dest);
                else
                    FileSystem.CopyDirectory(source, dest);
                destList.Items.Add((ListViewItem)toDrop.Clone());

            }
            catch (IOException)
            {
                MessageBox.Show("Operation failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Operation failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list1.Items.Clear();
            string drive = comboBox1.SelectedItem.ToString();
 
            updateDirs(getDirsList(drive), list1);//katalogi z wybranego dysku do listview
            updateFiles(getFilesList(drive), list1);//pliki z wybranego dysku do listview

            fw.Dir = comboBox1.SelectedItem.ToString();//wgranie ścieżki do dysku w zmienną pośredniczącą

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            list2.Items.Clear();
            string drive = comboBox2.SelectedItem.ToString();     
            
            updateDirs(getDirsList(drive), list2);//katalogi z wybranego dysku do listview
            updateFiles(getFilesList(drive), list2);//pliki z wybranego dysku do listview

            fw.Dir2 = comboBox2.SelectedItem.ToString();//wgranie ścieżki do dysku w zmienną pośredniczącą
        }       

        private void list1_DoubleClick(object sender, EventArgs e)
        {
            fw.Dir = listUpdate(list1, fw.Dir);//wgranie ścieżki do dysku w zmienną pośredniczącą
            //listUpdate zwraca curdir
        }

        private void list2_DoubleClick(object sender, EventArgs e)
        {           
            fw.Dir2 = listUpdate(list2, fw.Dir2);//wgranie ścieżki do dysku w zmienną pośredniczącą
            //listUpdate zwraca curdir
        }

        private void SortButton_list1_col1_Click(object sender, EventArgs e)//sortowanie - pierwsza lista, pierwsza kolumna
        {
            list1.ListViewItemSorter = new ListViewItemComparer(0, fw.OrderOfSort); 
            list1.Sort(); 
            fw.OrderOfSort = fw.OrderOfSort * -1;
        }

        private void SortButton_list2_col1_Click(object sender, EventArgs e) //sortowanie - druga lista, pierwsza kolumna
        {
            list2.ListViewItemSorter = new ListViewItemComparer(0, fw.OrderOfSort2); 
            list2.Sort();
            fw.OrderOfSort2 = fw.OrderOfSort2 * -1;
        }

        private void SortButton_list1_col2_Click(object sender, EventArgs e)//sortowanie - pierwsza lista, druga kolumna
        {
            list1.ListViewItemSorter = new ListViewItemComparer(1, fw.OrderOfSort);
            list1.Sort();
            fw.OrderOfSort = fw.OrderOfSort * -1;
        }

        private void SortButton_list2_col2_Click(object sender, EventArgs e) //sortowanie - druga lista, druga kolumna
        {
            list2.ListViewItemSorter = new ListViewItemComparer(1, fw.OrderOfSort2); 
            list2.Sort();
            fw.OrderOfSort2 = fw.OrderOfSort2 * -1;
        }


        
        private void list1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)56)
            {
                deleteDir(list1, fw.Dir);               
            }
            if (e.KeyChar == (char)55)
                createDir(list1, fw.Dir);
        }

        private void list2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)56)
            {
                deleteDir(list2, fw.Dir2);
            }
            if (e.KeyChar == (char)55)
                createDir(list2, fw.Dir2);
        }

        private void list1_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Move;
        }

        private void list2_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Move;
        }

        private void list1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            list1.DoDragDrop(list1.SelectedItems[0], DragDropEffects.Move);
        }

        private void list2_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                copyByDrop(list1, list2, fw.Dir, fw.Dir2, list1.SelectedItems[0]);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Operation failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void list2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            list2.DoDragDrop(list2.SelectedItems[0], DragDropEffects.Move);
        }

        private void list1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                copyByDrop(list2, list1, fw.Dir2, fw.Dir, list2.SelectedItems[0]);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Operation failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
/*do zrobienia:
>> podwójne odmowa dostępu - ok
>> zła ścieżka po odmowie dostępu (zostaje /Settings(..)) - ok
>> SYF NADAL po filenotfound/dir notfound: jeśli wybieram ten sam dysk, nie aktualizuje się lista (bo tylko indexchanged w comboboxach?)
>> czy zadziała usuwanie plików? -- NIE DZIAŁA
 */

