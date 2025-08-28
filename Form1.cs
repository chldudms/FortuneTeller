using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace fortuneTeller
{
    public partial class Form1 : Form
    {
        List<string> results;

        public Form1()
        {
            InitializeComponent();
            LoadResults();
        }

        private void LoadResults()
        {

            try
            {
                string filename = "results.csv";
                results = File.ReadAllLines(filename).ToList();

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("결과 파일을 찾을 수 없습니다: \n{ex.Message}", "파일 없음",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(".권한이 없습니다: \n{ex.Message}", "권한 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("결과 파일을 불러오는 중 오류가 발생했습니다: \n{ex.Message}", "알 수 없는 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 내용불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistory formHistory = Application.OpenForms["FormHistory"] as FormHistory;
            if (formHistory != null)
            {
                formHistory.Activate();

            }
            else
            {
                formHistory = new FormHistory(this);
                formHistory.Show();

            }
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 포츈텔러정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string birthday = tbBirthday.Text;
            string birthhour = tbBirthHour.Text;

            string result = GetFortune();

            string saju = result.Split('|')[0];
            string message = result.Split('|')[1];

            tbResult.Text = $"{birthday} {birthhour}{Environment.NewLine}"
           + $"{saju}{Environment.NewLine}"
           + $"{message}";
            SaveHistory($"{birthday} {birthhour}|{result}");
        }

        private string GetFortune()
        {
            Random random = new Random();
            int index = random.Next(0,results.Count);
            return results[index]; 
        }

        private void SaveHistory(string history)
        {
            try
            {
             string filename = "history.csv";
             File.AppendAllText(filename, history + Environment.NewLine);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show($"권한 없음 오류 발생 \n{ex.Message}","권한 오류");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알 수 없는 오류 발생 \n{ex.Message}", "알 수 없는 오류");

            }
        }
           
        private void tbBirthday_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBirthHour_TextChanged(object sender, EventArgs e)
        {

        }
    }
}