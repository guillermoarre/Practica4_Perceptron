using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica4_Agentes
{
    public partial class Form1 : Form
    {
        int indice, contador;
        double w1, w2, w3, w4, umbral;
        
        public Form1()
        {
            w1 = w2 = w3 = w4 = umbral = 0;
           
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            borrarDataGrid();
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Resuelve el perceptron
            if (indice == 0 || indice == 1 || indice == 2)
            {
                contador = 0;
                ResuelveCompuerta();
            }
            else if (indice == 3)
            {
                contador = 0;
                ResuelveMayoria();
            }
            else if (indice == 4) 
            {
                contador = 0;
                ResuelveParidad();

            }
            else if (indice == 5)
            {
                contador = 0;
                ResuelveEjercicio();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice = comboBox1.SelectedIndex;
            realizaTabla(indice);
           
        }

        public void realizaTabla(int caso)
        {
            int m, n;
            if (caso == 0 || caso == 1 || caso == 2)
            {
                borrarDataGrid();
                //AND, OR & XOR
                m = 4;
                n = 4;
                dataGridView1.RowCount = m;
                dataGridView1.ColumnCount = n;
                dataGridView1.Columns[0].HeaderText = "X1";
                dataGridView1.Columns[1].HeaderText = "X2";
                dataGridView1.Columns[2].HeaderText = "Yesp";
                dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[3].HeaderText = "Ycal";
                dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                llenarTablaDeVerdad(m, n - 2);
            }
            else if (caso == 3)
            {
                borrarDataGrid();
                //Mayoria Simple
                m = 8;
                n = 5;
                dataGridView1.RowCount = m;
                dataGridView1.ColumnCount = n;
                dataGridView1.Columns[0].HeaderText = "X1";
                dataGridView1.Columns[1].HeaderText = "X2";
                dataGridView1.Columns[2].HeaderText = "X3";
                dataGridView1.Columns[3].HeaderText = "Yesp";
                dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[4].HeaderText = "Ycal";
                dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                llenarTablaDeVerdad(m, n - 2);
            }
            else if (caso == 4)
            {
                borrarDataGrid();
                //Paridad
                m = 16;
                n = 6;
                dataGridView1.RowCount = m;
                dataGridView1.ColumnCount = n;
                dataGridView1.Columns[0].HeaderText = "X1";
                dataGridView1.Columns[1].HeaderText = "X2";
                dataGridView1.Columns[2].HeaderText = "X3";
                dataGridView1.Columns[3].HeaderText = "X4";
                dataGridView1.Columns[4].HeaderText = "Yesp";
                dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[5].HeaderText = "Ycal";
                dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                llenarTablaDeVerdad(m, n - 2);

            }
            else if (caso == 5)
            {
                borrarDataGrid();
                //Ejemplo
                m = 6;
                n = 4;
                dataGridView1.RowCount = m;
                dataGridView1.ColumnCount = n;
                dataGridView1.Columns[0].HeaderText = "X1";
                dataGridView1.Columns[1].HeaderText = "X2";
                dataGridView1.Columns[2].HeaderText = "Yesp";
                dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[3].HeaderText = "Ycal";
                dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                llenarTablaDeVerdad(m, n);

            }
        }

        public void llenarTablaDeVerdad(int m, int n)
        {
            int i, j, c = 0, x2 = 0;
            int x1 = m / 2;
            if (indice != 5)
            {
                for (j = 0; j < n; j++)
                {
                    for (i = 0; i < m; i++)
                    {
                        if (x2 == 0)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = 0;
                            c++;
                        }
                        else if (x2 == 1)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = 1;
                            c--;
                        }
                        if (c == x1)
                        {
                            //llegaste a la mitad de la tabla
                            x2 = 1;
                        }
                        if (c == 0)
                        {
                            //terminaste con la columa Xn
                            x2 = 0;
                        }
                    }
                    x1 = x1 / 2;
                }
            }
            else 
            {
                //VALORES DE TABLA DE ENTRADA DE Ejercicio
                dataGridView1.Rows[0].Cells[0].Value = 2;
                dataGridView1.Rows[1].Cells[0].Value = 0;
                dataGridView1.Rows[2].Cells[0].Value = 2;
                dataGridView1.Rows[3].Cells[0].Value = 0;
                dataGridView1.Rows[4].Cells[0].Value = 1;
                dataGridView1.Rows[5].Cells[0].Value = 1;

                dataGridView1.Rows[0].Cells[1].Value = 0;
                dataGridView1.Rows[1].Cells[1].Value = 0;
                dataGridView1.Rows[2].Cells[1].Value = 2;
                dataGridView1.Rows[3].Cells[1].Value = 1;
                dataGridView1.Rows[4].Cells[1].Value = 1;
                dataGridView1.Rows[5].Cells[1].Value = 2;

            }


            //Llena los resultados esperados
            if (indice == 0)
            {
                //AND
                dataGridView1.Rows[0].Cells[2].Value = -1;
                dataGridView1.Rows[1].Cells[2].Value = -1;
                dataGridView1.Rows[2].Cells[2].Value = -1;
                dataGridView1.Rows[3].Cells[2].Value = 1;

            }
            else if (indice == 1)
            {
                //OR
                dataGridView1.Rows[0].Cells[2].Value = -1;
                dataGridView1.Rows[1].Cells[2].Value = 1;
                dataGridView1.Rows[2].Cells[2].Value = 1;
                dataGridView1.Rows[3].Cells[2].Value = 1;
            }
            else if (indice == 2)
            {
                //XOR
                dataGridView1.Rows[0].Cells[2].Value = -1;
                dataGridView1.Rows[1].Cells[2].Value = 1;
                dataGridView1.Rows[2].Cells[2].Value = 1;
                dataGridView1.Rows[3].Cells[2].Value = -1;
            }
            else if (indice == 3)
            {
                //Mayoria Simple
                dataGridView1.Rows[0].Cells[3].Value = -1;
                dataGridView1.Rows[1].Cells[3].Value = -1;
                dataGridView1.Rows[2].Cells[3].Value = -1;
                dataGridView1.Rows[3].Cells[3].Value = 1;
                dataGridView1.Rows[4].Cells[3].Value = -1;
                dataGridView1.Rows[5].Cells[3].Value = 1;
                dataGridView1.Rows[6].Cells[3].Value = 1;
                dataGridView1.Rows[7].Cells[3].Value = 1;

            }
            else if (indice == 4)
            {
                int contador = 0;
                //Paridad
                for (i = 0; i < 16; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "1")
                        {
                            contador++;
                        }
                    }
                    if (contador % 2 == 0 && i != 0)
                    {
                        //Es par
                        dataGridView1.Rows[i].Cells[4].Value = 1;
                    }
                    else
                    {
                        //Es impar
                        dataGridView1.Rows[i].Cells[4].Value = -1;

                    }
                    contador = 0;
                }

            }
            else
            {
                //Ejercicio
                dataGridView1.Rows[0].Cells[2].Value = 1;
                dataGridView1.Rows[1].Cells[2].Value = -1;
                dataGridView1.Rows[2].Cells[2].Value = 1;
                dataGridView1.Rows[3].Cells[2].Value = -1;
                dataGridView1.Rows[4].Cells[2].Value = 1;
                dataGridView1.Rows[5].Cells[2].Value = -1;

            }

        }

        public void borrarDataGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            listBox1.Items.Clear();
        }
        public void primerosValores()
        {
            if (indice == 0 || indice == 1 || indice == 2 || indice == 5)
            {
                listBox1.Items.Add("->Pesos Origs.");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("Umbral Orig. = " + umbral.ToString());
            }
            else if (indice == 3)
            {
                listBox1.Items.Add("->Pesos Origs.");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("W3 = " + w3.ToString());
                listBox1.Items.Add("Umbral Orig. = " + umbral.ToString());
            }
            else if(indice == 4)
            {
                listBox1.Items.Add("->Pesos Origs.");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("W3 = " + w3.ToString());
                listBox1.Items.Add("W4 = " + w4.ToString());
                listBox1.Items.Add("Umbral Orig. = " + umbral.ToString());
            }
        }


        //Operaciones Lógicas
        public void ResuelveCompuerta()
        {
            //valores aleatorios
            w1 = 1;
            w2 = 1;
            umbral = 0.5;
            int i;
            primerosValores();
            do 
            { 
            for (i = 0; i < 4; i++)
            {
                if (OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(),dataGridView1.Rows[i].Cells[1].Value.ToString()) == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    //Clasificó bien          
                }
                else
                {
                    //Clasificó mal
                    OperaAprendizaje2(i);
                }
            }
                //Época terminada
                //Evalua con los valores obtenidos
            }
            while(!EvaluaEpocaActual() && !(contador>100));

            if (contador > 100)
            {
                MessageBox.Show("Solución NO encontrada!!!!");
            }
            else
            {
                MessageBox.Show("Solución encontrada!!!!");
            }

        }
        public string OperaAprendizaje1(string x1, string x2)
        {
            double x1d, x2d, var;
            x1d = double.Parse(x1);
            x2d = double.Parse(x2);
            var = x1d * w1 + x2d * w2 + umbral;
            if (var > 0)
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
        public void OperaAprendizaje2(int fila)
        {
            double dx, dw1, dw2, dw0,x1,x2;
            dx = dw1 = dw2 = dw0=x1 =x2 = 0.0;
            x1 = double.Parse(dataGridView1.Rows[fila].Cells[0].Value.ToString());
            x2 = double.Parse(dataGridView1.Rows[fila].Cells[1].Value.ToString());
            dx = double.Parse(dataGridView1.Rows[fila].Cells[2].Value.ToString());
            dw1 = dx * x1;
            dw2 = dx * x2;
            w1 = w1 + dw1;
            w2 = w2 + dw2;
            umbral = umbral + dx;
        }
        public bool EvaluaEpocaActual()
        {
            bool flagaux = true;
            contador++;
            int i;
            listBox1.Items.Add("");
            listBox1.Items.Add("\nEpoca = "+contador.ToString());
            for (i = 0; i < 4; i++)
            {
                if (OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString()) == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    //Se Clasificó bien
                    dataGridView1.Rows[i].Cells[3].Value = OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
                else
                {
                    //Se Clasificó mal
                    dataGridView1.Rows[i].Cells[3].Value = OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
                    flagaux = false;
                }
                listBox1.Items.Add("->Pesos");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("Umbral = " + umbral.ToString());
                listBox1.Items.Add("->Entrada " + i.ToString() + "\n");
            }
            return flagaux;
        }

        //Mayoria Simple
        public void ResuelveMayoria()
        {
            //valores aleatorios
            w1 = 1;
            w2 = 1;
            w3 = 1;
            umbral = 0.5;
            int i;
            primerosValores();
            do
            {
                for (i = 0; i < 8; i++)
                {
                    if (OperaAprendizaje3(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString()) == dataGridView1.Rows[i].Cells[3].Value.ToString())
                    {
                        //Clasificó bien          
                    }
                    else
                    {
                        //Clasificó mal
                        OperaAprendizaje4(i);
                    }
                }
                //Época terminada
                //Evalua con los valores obtenidos
            }
            while (!EvaluaEpocaActual_MS() && !(contador > 100));

            if (contador > 100)
            {
                MessageBox.Show("Solución NO encontrada!!!!");
            }
            else
            {
                MessageBox.Show("Solución encontrada!!!!");
            }
        }
        public string OperaAprendizaje3(string x1, string x2, string x3)
        {
            double x1d, x2d,x3d, var;
            x1d = double.Parse(x1);
            x2d = double.Parse(x2);
            x3d = double.Parse(x3);
            var = x1d * w1 + x2d * w2 + x3d * w3 + umbral;
            if (var > 0)
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
        public void OperaAprendizaje4(int fila)
        {
            double dx, dw1, dw2, dw3, dw0, x1, x2,x3;
            dx = dw1 = dw2 = dw0 = x1 = x2 = 0.0;
            x1 = double.Parse(dataGridView1.Rows[fila].Cells[0].Value.ToString());
            x2 = double.Parse(dataGridView1.Rows[fila].Cells[1].Value.ToString());
            x3 = double.Parse(dataGridView1.Rows[fila].Cells[2].Value.ToString());
            dx = double.Parse(dataGridView1.Rows[fila].Cells[3].Value.ToString());
            dw1 = dx * x1;
            dw2 = dx * x2;
            dw3 = dx * x3;
            w1 = w1 + dw1;
            w2 = w2 + dw2;
            w3 = w3 + dw3;
            umbral = umbral + dx;
        }
        public bool EvaluaEpocaActual_MS()
        {
            bool flagaux = true;
            contador++;
            int i;
            listBox1.Items.Add("");
            listBox1.Items.Add("\nEpoca = " + contador.ToString());
            for (i = 0; i < 8; i++)
            {
                if (OperaAprendizaje3(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString()) == dataGridView1.Rows[i].Cells[3].Value.ToString())
                {
                    //Se Clasificó bien
                    dataGridView1.Rows[i].Cells[4].Value = OperaAprendizaje3(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                else
                {
                    //Se Clasificó mal
                    dataGridView1.Rows[i].Cells[4].Value = OperaAprendizaje3(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                    flagaux = false;
                }
                listBox1.Items.Add("->Pesos");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("W3 = " + w3.ToString());
                listBox1.Items.Add("Umbral = " + umbral.ToString());
                listBox1.Items.Add("->Entrada " + i.ToString() + "\n");
            }
            return flagaux;
        }

        //Paridad
        public void ResuelveParidad()
        {
            //valores aleatorios
            w1 = 1;
            w2 = 1;
            w3 = 1;
            w4 = 1;
            umbral = 0.5;
            int i;
            primerosValores();
            do
            {
                for (i = 0; i < 16; i++)
                {
                    if (OperaAprendizaje5(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString()) == dataGridView1.Rows[i].Cells[4].Value.ToString())
                    {
                        //Clasificó bien          
                    }
                    else
                    {
                        //Clasificó mal
                        OperaAprendizaje6(i);
                    }
                }
                //Época terminada
                //Evalua con los valores obtenidos
            }
            while (!EvaluaEpocaActual_Paridad() && !(contador > 100));

            if (contador > 100)
            {
                MessageBox.Show("Solución NO encontrada!!!!");
            }
            else
            {
                MessageBox.Show("Solución encontrada!!!!");
            }

        }
        public string OperaAprendizaje5(string x1, string x2, string x3, string x4)
        {
            double x1d, x2d, x3d,x4d, var;
            x1d = double.Parse(x1);
            x2d = double.Parse(x2);
            x3d = double.Parse(x3);
            x4d = double.Parse(x4);
            var = x1d * w1 + x2d * w2 + x3d * w3 + x4d * w4 + umbral;
            if (var > 0)
            {
                return "1";
            }
            else
            {
                return "-1";
            }

        }
        public void OperaAprendizaje6(int fila)
        {
            double dx, dw1, dw2, dw3,dw4, dw0, x1, x2, x3,x4;
            dx = dw1 = dw2 =dw3=dw4 = dw0 = x1 = x2 =x3=x4= 0.0;
            x1 = double.Parse(dataGridView1.Rows[fila].Cells[0].Value.ToString());
            x2 = double.Parse(dataGridView1.Rows[fila].Cells[1].Value.ToString());
            x3 = double.Parse(dataGridView1.Rows[fila].Cells[2].Value.ToString());
            x4 = double.Parse(dataGridView1.Rows[fila].Cells[3].Value.ToString());
            dx = double.Parse(dataGridView1.Rows[fila].Cells[4].Value.ToString());
            dw1 = dx * x1;
            dw2 = dx * x2;
            dw3 = dx * x3;
            dw4 = dx * x4;
            w1 = w1 + dw1;
            w2 = w2 + dw2;
            w3 = w3 + dw3;
            w4 = w4 + dw4;
            umbral = umbral + dx;

        }
        public bool EvaluaEpocaActual_Paridad()
        {
            bool flagaux = true;
            contador++;
            int i;
            listBox1.Items.Add("");
            listBox1.Items.Add("\nEpoca = " + contador.ToString());
            for (i = 0; i < 16; i++)
            {
                if (OperaAprendizaje5(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString()) == dataGridView1.Rows[i].Cells[4].Value.ToString())
                {
                    //Se Clasificó bien
                    dataGridView1.Rows[i].Cells[5].Value = OperaAprendizaje5(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                else
                {
                    //Se Clasificó mal
                    dataGridView1.Rows[i].Cells[5].Value = OperaAprendizaje5(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                    flagaux = false;
                }
                listBox1.Items.Add("->Pesos");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("W3 = " + w3.ToString());
                listBox1.Items.Add("W4 = " + w4.ToString());
                listBox1.Items.Add("Umbral = " + umbral.ToString());
                listBox1.Items.Add("->Entrada " + i.ToString() + "\n");
            }
            return flagaux;

        }

        //Ejercicio 1
        public void ResuelveEjercicio()
        {
            //valores aleatorios
            w1 = 1;
            w2 = 1;
            umbral = 0.5;
            int i;
            primerosValores();
            do
            {
                for (i = 0; i < 6; i++)
                {
                    if (OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString()) == dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        //Clasificó bien          
                    }
                    else
                    {
                        //Clasificó mal
                        OperaAprendizaje2(i);
                    }
                }
                //Época terminada
                //Evalua con los valores obtenidos
            }
            while (!EvaluaEpocaActual_Ejercicio() && !(contador > 100));

            if (contador > 100)
            {
                MessageBox.Show("Solución NO encontrada!!!!");
            }
            else
            {
                MessageBox.Show("Solución encontrada!!!!");
            }

        }
        public bool EvaluaEpocaActual_Ejercicio()
        {
            bool flagaux = true;
            contador++;
            int i;
            listBox1.Items.Add("");
            listBox1.Items.Add("\nEpoca = " + contador.ToString());
            for (i = 0; i < 6; i++)
            {
                if (OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString()) == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    //Se Clasificó bien
                    dataGridView1.Rows[i].Cells[3].Value = OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
                else
                {
                    //Se Clasificó mal
                    dataGridView1.Rows[i].Cells[3].Value = OperaAprendizaje1(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
                    flagaux = false;
                }
                listBox1.Items.Add("->Pesos");
                listBox1.Items.Add("W1 = " + w1.ToString());
                listBox1.Items.Add("W2 = " + w2.ToString());
                listBox1.Items.Add("Umbral = " + umbral.ToString());
                listBox1.Items.Add("->Entrada " + i.ToString() + "\n");
            }
            return flagaux;
        }
    }
}
