using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UcnPractic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BoxChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BoxChildren.SelectedItem != null && BoxChildren.SelectedItem.ToString() == "С детьми")
            {
                label7.Visible = true;
                numericUpDown1.Visible = true;
            }
            else
            {
                label7.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtData.Text = Calendar.SelectionStart.ToShortDateString();
        }
        private int button1Clicks = 0;
        public void button2_Click(object sender, EventArgs e)
        {
            string url = "https://www.aviasales.ru/?marker=15468.gaasru8877gclidCjwKCAiA98WrBhAYEiwA2WvhOtrw3SzZQXPzEYGBLzWbWeYNxJnh3zQCUYRFem3tlDLyZUk-i8B_pxoCvPAQAvD_BwEgclid&gad_source=1&gclid=CjwKCAiA98WrBhAYEiwA2WvhOtrw3SzZQXPzEYGBLzWbWeYNxJnh3zQCUYRFem3tlDLyZUk-i8B_pxoCvPAQAvD_BwE&params=AMS1";

            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, заполнены ли все поля
            if (!string.IsNullOrEmpty(txtFam.Text) &&
                !string.IsNullOrEmpty(txtName.Text) &&
                !string.IsNullOrEmpty(txtOth.Text) &&
                !string.IsNullOrEmpty(txtNoum.Text) &&
                !string.IsNullOrEmpty(txtData.Text) &&
                checkedList.CheckedItems.Count > 0)
            {
                // Увеличиваем счетчик нажатий кнопки и обновляем метку
                button1Clicks++;
                
            }
            else
            {
                // Выводим сообщение об ошибке, если не все поля заполнены
                MessageBox.Show("Заполните все поля перед обновлением", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            double totalCost = 0;

            // Проверка выбранного направления в comboReis
            string selectedRoute = comboReis.SelectedItem.ToString();
            if (selectedRoute == "Екатеринбург >Санкт-Петербург")
            {
                totalCost += 2000;
            }
            else if (selectedRoute == "Москва > Красноярск" || selectedRoute == "Екатеринбург > Варшава")
            {
                totalCost += 2000;
            }
            else if (selectedRoute == "Санкт-Петербург > Стамбул")
            {
                totalCost += 5000;
            }
            else if (selectedRoute == "Новосибирск > Дубаи")
            {
                totalCost += 10000;
            }

            // Проверка выбранных опций
            if (checkedList.CheckedItems.Contains("Багаж"))
            {
                totalCost += 300;
            }
            if (checkedList.CheckedItems.Contains("Обратный билет"))
            {
                totalCost *= 2;
            }
            if (BoxChildren.SelectedItem != null && BoxChildren.SelectedItem.ToString() == "С детьми")
            {
                totalCost += 1500 * (int)numericUpDown1.Value;
            }

            // Проверка выбранного класса в BoxKlass
            string selectedClass = BoxKlass.SelectedItem.ToString();
            if (selectedClass == "Комфорт")
            {
                totalCost += 500;
            }
            else if (selectedClass == "Бизнес")
            {
                totalCost += 2000;
            }
            else if (selectedClass == "Первый класс")
            {
                totalCost += 5000;
            }

            // Добавление стоимости за количество детей и дополнительный багаж из numericUpDown1 и numericUpDown2
            totalCost += 2500 * (int)numericUpDown2.Value;

            // Отображение окна с итоговой стоимостью
            MessageBox.Show($"Итоговая стоимость билета: {totalCost} рублей", "Стоимость билета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Элементы по умолчанию
            BoxChildren.SelectedItem = "С детьми";
            BoxKlass.SelectedItem = "Эконом";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtFam.Text = " ";
            txtName.Text = " ";
            txtOth.Text = " ";
            txtNoum.Text = " ";
            txtData.Text = " ";
            comboReis.Text = " ";
            numericUpDown2.Value = 0;
            numericUpDown1.Value = 0;
            BoxKlass.Text = "Эконом";
        }
    }
}
