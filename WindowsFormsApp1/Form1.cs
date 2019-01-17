using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int width = 661, height = 661, cellAmount = 132, phaseAmount;
        public int cellSize = 4;
        public Bitmap bmp;
        public Graphics bmpGraphic;
        public Color myColor = Color.FromArgb(0, 34, 100);
        public SolidBrush myBrush;
        public int[,] grid, newGrid, phase, energy, energySRX;
        public ArrayList colors;
        public int grainsAmount, inclusionAmount, inclusionSize, colouredBoundarySize, previousAmount = 0;
        double J_energy;
        bool running = false, reset = false, inclusion = false, clear = false, colouring = false, import = false, substructure = false, monte = false, clearingSRX = false;
        int czyWypelniona = -1, clicked = -1;
        Thread growth, monte_growth;
        Random rand = new Random();
        int neighbourCondition = 0, positionCondition = 0, boundaryCondition = 0, inclusionCondition = 0, colouredBoundaryCondition = 0, substructureCondition = 0, distributionCondition = 0;
        public ArrayList choosenGrains, monteColors;
        int colorInt;
        string colorHex;

        public int[,] inclusions;
        int iteration, iterationNumber, iterationNumerPrevious;


        public Form1()
        {
            InitializeComponent();
        }

        void locateGrains()
        {
            int v = 1, x, z;
            if (positionCondition == 1)
                for (int y = 0; y < grainsAmount; y++)
                {
                    z = rand.Next(cellAmount);
                    x = rand.Next(cellAmount);
                    while (phase[z, x] != 0)
                    {
                        z = rand.Next(cellAmount);
                        x = rand.Next(cellAmount);
                    }

                    for (int ch = 0; ch < choosenGrains.Count; ch++)
                        if ((int)choosenGrains[ch] == v)
                        {
                            v++;
                            break;
                        }

                    grid[z, x] = v;
                    v++;
                }
            else if (positionCondition == 2)
            {
                for (int y = 0; y < grainsAmount; y++)
                {
                    z = y * cellAmount / grainsAmount;
                    x = 0;
                    while (phase[z, x] != 0)
                        x++;

                    grid[z, x] = v;
                    v++;
                }
            }

            growth = new Thread(run);
            growth.Start();
        }


        void run()
        {
            int prevTick = 0;
            while (running)
            {
                int curTick = DateTime.Now.Millisecond;

                draw_image();
                if (curTick != prevTick)
                {
                    update();
                    prevTick = curTick;
                }

                Thread.Sleep(100);
            }
            while (monte)
            {
                int curTick = DateTime.Now.Millisecond;


                if (curTick != prevTick)
                {
                    updateMonte();
                    prevTick = curTick;
                }
                draw_image();
                Thread.Sleep(100);
            }
        }
        
        void update()
        {
            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                    newGrid[y, x] = grid[y, x];

            if (neighbourCondition == 1)
                vonNeumann();
            else if (neighbourCondition == 2)
                moore();
        }

        void vonNeumann()
        {
            for (int y = 0; y < cellAmount; y++)
            {
                for (int x = 0; x < cellAmount; x++)
                {

                    if (newGrid[y, x] == 0)
                    {
                        colors.Clear();

                        if (y - 1 >= 0 && newGrid[y - 1, x] > 0 && phase[y - 1, x] == 0)
                            colors.Add(newGrid[y - 1, x]);
                        if (boundaryCondition == 1 && y - 1 < 0 && newGrid[cellAmount - 1, x] > 0 && phase[cellAmount - 1, x] == 0)
                            colors.Add(newGrid[cellAmount - 1, x]);

                        if (x + 1 <= cellAmount - 1 && newGrid[y, x + 1] > 0 && phase[y, x + 1] == 0)
                            colors.Add(newGrid[y, x + 1]);
                        if (boundaryCondition == 1 && x + 1 > cellAmount - 1 && newGrid[y, 0] > 0 && phase[y, 0] == 0)
                            colors.Add(newGrid[y, 0]);

                        if (y + 1 <= cellAmount - 1 && newGrid[y + 1, x] > 0 && phase[y + 1, x] == 0)
                            colors.Add(newGrid[y + 1, x]);
                        if (boundaryCondition == 1 && y + 1 > cellAmount - 1 && newGrid[0, x] > 0 && phase[0, x] == 0)
                            colors.Add(newGrid[0, x]);

                        if (x - 1 >= 0 && newGrid[y, x - 1] > 0 && phase[y, x - 1] == 0)
                            colors.Add(newGrid[y, x - 1]);
                        if (boundaryCondition == 1 && x - 1 < 0 && newGrid[y, cellAmount - 1] > 0 && phase[y, cellAmount - 1] == 0)
                            colors.Add(newGrid[y, cellAmount - 1]);

                        if (colors.Count > 0)
                            grid[y, x] = grid_color(colors);
                    }
                }
            }
        }

        void moore()
        {
            for (int y = 0; y < cellAmount; y++)
            {
                for (int x = 0; x < cellAmount; x++)
                {
                    if (newGrid[y, x] == 0)
                    {
                        colors.Clear();

                        if (y - 1 >= 0 && newGrid[y - 1, x] > 0 && phase[y - 1, x] == 0)
                            colors.Add(newGrid[y - 1, x]);
                        if (boundaryCondition == 1 && y - 1 < 0 && newGrid[cellAmount - 1, x] > 0 && phase[cellAmount - 1, x] == 0)
                            colors.Add(newGrid[cellAmount - 1, x]);

                        if (x + 1 <= cellAmount - 1 && newGrid[y, x + 1] > 0 && phase[y, x + 1] == 0)
                            colors.Add(newGrid[y, x + 1]);
                        if (boundaryCondition == 1 && x + 1 > cellAmount - 1 && newGrid[y, 0] > 0 && phase[y, 0] == 0)
                            colors.Add(newGrid[y, 0]);

                        if (y + 1 <= cellAmount - 1 && newGrid[y + 1, x] > 0 && phase[y + 1, x] == 0)
                            colors.Add(newGrid[y + 1, x]);
                        if (boundaryCondition == 1 && y + 1 > cellAmount - 1 && newGrid[0, x] > 0 && phase[0, x] == 0)
                            colors.Add(newGrid[0, x]);

                        if (x - 1 >= 0 && newGrid[y, x - 1] > 0 && phase[y, x - 1] == 0)
                            colors.Add(newGrid[y, x - 1]);
                        if (boundaryCondition == 1 && x - 1 < 0 && newGrid[y, cellAmount - 1] > 0 && phase[y, cellAmount - 1] == 0)
                            colors.Add(newGrid[y, cellAmount - 1]);

                        if (y - 1 >= 0 && x - 1 >= 0 && newGrid[y - 1, x - 1] > 0 && phase[y - 1, x - 1] == 0)
                            colors.Add(newGrid[y - 1, x - 1]);
                        if (boundaryCondition == 1 && y - 1 < 0 && x - 1 < 0 && newGrid[cellAmount - 1, cellAmount - 1] > 0 && phase[cellAmount - 1, cellAmount - 1] == 0)
                            colors.Add(newGrid[cellAmount - 1, cellAmount - 1]);

                        if (y - 1 >= 0 && x + 1 <= cellAmount - 1 && newGrid[y - 1, x + 1] > 0 && phase[y - 1, x + 1] == 0)
                            colors.Add(newGrid[y - 1, x + 1]);
                        if (boundaryCondition == 1 && y - 1 < 0 && x + 1 > cellAmount - 1 && newGrid[cellAmount - 1, 0] > 0 && phase[cellAmount - 1, 0] == 0)
                            colors.Add(newGrid[cellAmount - 1, 0]);

                        if (y + 1 <= cellAmount - 1 && x + 1 <= cellAmount - 1 && newGrid[y + 1, x + 1] > 0 && phase[y + 1, x + 1] == 0)
                            colors.Add(newGrid[y + 1, x + 1]);
                        if (boundaryCondition == 1 && y + 1 > cellAmount - 1 && x + 1 > cellAmount - 1 && newGrid[0, 0] > 0 && phase[0, 0] == 0)
                            colors.Add(newGrid[0, 0]);

                        if (y + 1 <= cellAmount - 1 && x - 1 >= 0 && newGrid[y + 1, x - 1] > 0 && phase[y + 1, x - 1] == 0)
                            colors.Add(newGrid[y + 1, x - 1]);
                        if (boundaryCondition == 1 && y + 1 > cellAmount - 1 && x - 1 < 0 && newGrid[0, cellAmount - 1] > 0 && phase[0, cellAmount - 1] == 0)
                            colors.Add(newGrid[0, cellAmount - 1]);

                        if (colors.Count > 0)
                            grid[y, x] = grid_color(colors);

                    }
                }
            }
        }

        int grid_color(ArrayList colors)
        {
            int[,] results = new int[colors.Count, 2];
            ArrayList results2 = new ArrayList();

            for (int i = 0; i < colors.Count; i++)
            {

                results[i, 0] = (int)colors[i];
                results[i, 1] = 1;

                for (int j = i + 1; j < colors.Count; j++)
                    if (colors[j] == colors[i])
                    {
                        results[i, 1]++;
                        colors.Remove(colors[j]);
                    }
            }

            results2.Add(results[0, 0]);
            int max = results[0, 1];
            int returnedValue = results[0, 0];
            bool draw = false;

            for (int i = 1; i < colors.Count; i++)
            {
                if (results[i, 1] > max)
                {
                    results2.Clear();
                    results2.Add(results[i, 0]);
                    max = results[i, 1];
                    returnedValue = results[i, 0];
                    draw = false;
                }
                else if (results[i, 1] == max)
                {
                    draw = true;
                    results2.Add(results[i, 0]);
                }
            }

            int indexWhenDraw = 0;
            if (draw == true)
            {
                indexWhenDraw = rand.Next(results2.Count);
                returnedValue = results[indexWhenDraw, 0];
            }


            return returnedValue;
        }

        void DrawGrid(Graphics bmpGraphic)
        {
            if (czyWypelniona != 0 || reset || inclusion || clear || substructure || monte || clearingSRX)
            {
                for (int posY = 0; posY <= height; posY += cellSize + 1)
                {
                    for (int posX = 0; posX <= width; posX += cellSize + 1)
                    {
                        bmpGraphic.FillRectangle(Brushes.White, posX, posY, cellSize, cellSize);
                        bmpGraphic.FillRectangle(Brushes.Black, posX + cellSize, posY, 1, cellSize + 1);
                        bmpGraphic.FillRectangle(Brushes.Black, posX, posY + cellSize, cellSize + 1, 1);
                    }
                }
            }
        }


        void draw_image()
        {
            if (czyWypelniona == 0)
                running = false;

            if (czyWypelniona != 0 || previousAmount > 0 || monte || clearingSRX)
            {
                DrawGrid(bmpGraphic);
                if (running || inclusion || import || monte || clearingSRX)
                {
                    
                    czyWypelniona = 0;
                    for (int y = 0; y < cellAmount; y++)
                        for (int x = 0; x < cellAmount; x++)
                        {
                            if (grid[y, x] > 0 && phase[y, x] == 0)
                            {  // Console.WriteLine("IN");
                                colorInt = 16777215 - (grid[y, x] * 109000);
                                colorHex = colorInt.ToString("X");
                                Color color = Color.FromArgb(255,
                                                int.Parse(colorHex.Substring(0, 2), NumberStyles.HexNumber),
                                                int.Parse(colorHex.Substring(2, 2), NumberStyles.HexNumber),
                                                int.Parse(colorHex.Substring(4, 2), NumberStyles.HexNumber));
                                bmpGraphic.FillRectangle(new SolidBrush(color), x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                            }
                            else if (grid[y, x] == 0)
                                czyWypelniona++;
                        }
                }
            }

            if (substructure)
                draw_substructure(bmpGraphic);

            if (inclusion)
                draw_inclusions(bmpGraphic);

            if (running || inclusion || import || substructure || monte || clearingSRX)
                pictureBox.Image = bmp;

        }

        void draw_inclusions(Graphics bmpGraphic)
        {
            int basic = 0, start = 0, middle, halfMiddle, basic2, basicWhile;

            if (inclusionCondition == 1)
                for (int i = 0; i < inclusionAmount; i++)
                    for (int y = 0; y < inclusionSize; y++)
                        for (int x = 0; x < inclusionSize; x++)
                            bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);

            else if (inclusionCondition == 2)
            {
                int x, t = 0;
                for (int i = 0; i < inclusionAmount; i++)
                {
                    basicWhile = basic = inclusionSize / 2;
                    while (basic > 1)
                    {
                        if (inclusionSize > Math.Pow(2, basic))
                            break;
                        basic--;
                    }
                    start = inclusionSize - basic;
                    basic2 = basic * 2;
                    middle = inclusionSize - basic - 1;
                    halfMiddle = middle / 2;

                    for (int y = 0; y < inclusionSize; y++)
                    {
                        if (y == 0)
                            for (x = 0; x < basic2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);

                        else if (y > 0 && y < halfMiddle)
                        {
                            start -= 2;
                            basic2 += 4;
                            for (x = 0; x < basic2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                            t = 1;
                        }
                        else if (y > halfMiddle + 1 && y < inclusionSize - basic && middle % 2 != 0)
                        {
                            if (t == 1)
                            {
                                start--;
                                basic2 += 2;
                                for (x = 0; x < basic2; x++)
                                    bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                t = 2;
                            }
                            else if (t == 2)
                            {
                                for (x = 0; x < basic2; x++)
                                    bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                t = 1;
                            }
                        }
                        else if (y > halfMiddle && y < inclusionSize - basic && middle % 2 == 0)
                        {
                            if (t == 1)
                            {
                                start--;
                                basic2 += 2;
                                for (x = 0; x < basic2; x++)
                                    bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                t = 2;
                            }
                            else if (t == 2)
                            {
                                for (x = 0; x < basic2; x++)
                                    bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                t = 1;
                            }
                        }

                        else if (y >= inclusionSize - basic)
                            for (x = 0; x < inclusionSize * 2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                        else
                        {
                            start--;
                            basic2 += 2;
                            for (x = 0; x < basic2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                            t = 1;
                        }
                    }
                    start = 0;
                    basic2 = inclusionSize * 2;
                    for (int y = 0; y < inclusionSize; y++)
                    {
                        middle = inclusionSize - basic - 1;
                        halfMiddle = middle / 2;

                        if (y < basic)
                        {
                            for (x = 0; x < inclusionSize * 2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + x) * (cellSize + 1) - 1, (inclusions[i, 0] + inclusionSize + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                            t = 1;
                        }
                        else if (y >= basic && y < middle)
                        {
                            if (t == 1)
                            {
                                start++;
                                basic2 -= 2;
                                for (x = 0; x < basic2; x++)
                                    bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + inclusionSize + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                t = 2;
                            }
                            else if (t == 2)
                            {
                                for (x = 0; x < basic2; x++)
                                    bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + inclusionSize + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                t = 1;
                            }

                        }
                        else if (y > inclusionSize - halfMiddle && y < inclusionSize - 1)
                        {
                            start += 2;
                            basic2 -= 4;
                            for (x = 0; x < basic2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + inclusionSize + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                        }
                        else if (y == inclusionSize - 1)
                        {
                            start = inclusionSize - basic;
                            basic2 = basic * 2;
                            for (x = 0; x < basic2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + inclusionSize + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                        }
                        else
                        {
                            start++;
                            basic2 -= 2;
                            for (x = 0; x < basic2; x++)
                                bmpGraphic.FillRectangle(new SolidBrush(Color.Black), (inclusions[i, 1] + start + x) * (cellSize + 1) - 1, (inclusions[i, 0] + inclusionSize + y) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                        }
                    }
                }
            }
            previousAmount = inclusionAmount;
        }


        void start_growth(object sender, EventArgs e)
        {
            if (amountTextBox.Text != null)
                grainsAmount = Convert.ToInt32(amountTextBox.Text);

            colors = new ArrayList();
            czyWypelniona = -1;
            running = true;
            reset = false;
            if (neighbourCombo.Text == "von Neumann")
                neighbourCondition = 1;
            else if (neighbourCombo.Text == "Moore")
                neighbourCondition = 2;

            if (boundaryCombo.Text == "periodic")
                boundaryCondition = 1;
            else if (boundaryCombo.Text == "absorbing")
                boundaryCondition = 2;

            if (positionCombo.Text == "randomly")
                positionCondition = 1;
            else if (positionCombo.Text == "regular")
                positionCondition = 2;


            locateGrains();
        }


        void genarate_bitmap(object sender, EventArgs e)
        {
            grid = new int[cellAmount, cellAmount];
            newGrid = new int[cellAmount, cellAmount];
            choosenGrains = new ArrayList();
            monteColors = new ArrayList();
            phase = new int[cellAmount, cellAmount];
            energySRX = new int[cellAmount, cellAmount];

            if (substructure == false)
                phaseAmount = 1;

            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                {
                    grid[y, x] = 0;
                    energySRX[y,x] = 0;
                    if (substructure == false)
                        phase[y, x] = 0;
                }
            bmp = new Bitmap(width, height);
            bmpGraphic = Graphics.FromImage(bmp);

            DrawGrid(bmpGraphic);
            pictureBox.Image = bmp;
        }


        void reset_board(object sender, EventArgs e)
        {
            if (!running || running || inclusion || clear || colouring)
            {
                if (running)
                    growth.Abort();
                for (int y = 0; y < cellAmount; y++)
                    for (int x = 0; x < cellAmount; x++)
                    {
                        grid[y, x] = 0;
                        phase[y, x] = 0;
                    }
                reset = true;
                running = false;
                choosenGrains.Clear();
                inclusion = false;
                import = false;
                clear = false;
                clearingSRX = false;
                grainsAmount = 1;
                substructure = false;
                monte = false;
                //   draw_image();
                DrawGrid(bmpGraphic);
                pictureBox.Image = bmp;
            }
        }

        void add_boundaries(object sender, EventArgs e)
        {
            colouredBoundarySize = Convert.ToInt32(grainBoundarySizeTextBox.Text);
            running = false;
            colouring = true;
            if (grainBoundaryTypeCombo.Text == "all grains")
                colouredBoundaryCondition = 1;
            else if (grainBoundaryTypeCombo.Text == "choosen grains")
                colouredBoundaryCondition = 2;

            draw_boundaries(bmpGraphic);
        }

        void draw_boundaries(Graphics bmpGraphic)
        {
            if (colouredBoundaryCondition == 1)
            {
                for (int y = 0; y < cellAmount; y++)
                    for (int x = 0; x < cellAmount; x++)
                    {
                        if (x != cellAmount - 1 && grid[y, x] != grid[y, x + 1])
                        {
                            bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                            bmpGraphic.FillRectangle(Brushes.Black, (x + 1) * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                        }
                        else if (y != cellAmount - 1 && grid[y, x] != grid[y + 1, x])
                        {
                            bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                            bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, (y + 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                        }
                    }
                pictureBox.Image = bmp;
            }
            else if (colouredBoundaryCondition == 2 && choosenGrains.Count > 0)
            {
                for (int i = 0; i < choosenGrains.Count; i++)
                {
                    for (int y = 0; y < cellAmount; y++)
                    {
                        for (int x = 0; x < cellAmount; x++)
                        {
                            if (grid[y, x] == (int)choosenGrains[i])
                            {
                                if (grid[y, x] != grid[y, x + 1] && x != cellAmount - 1)
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, (x + 1) * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (y != cellAmount - 1 && grid[y, x] != grid[y + 1, x])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, (y + 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (x != 0 && grid[y, x] != grid[y, x - 1])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, (x - 1) * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (y != 0 && grid[y, x] != grid[y - 1, x])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, (y - 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (y != 0 && x != 0 && grid[y, x] != grid[y - 1, x - 1])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, (x - 1) * (cellSize + 1) - 1, (y - 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (y != 0 && x != cellAmount - 1 && grid[y, x] != grid[y - 1, x + 1])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, (x + 1) * (cellSize + 1) - 1, (y - 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (x != 0 && y != cellAmount - 1 && grid[y, x] != grid[y + 1, x - 1])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, (x - 1) * (cellSize + 1) - 1, (y + 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                                else if (x != cellAmount - 1 && y != cellAmount - 1 && grid[y, x] != grid[y + 1, x + 1])
                                {
                                    bmpGraphic.FillRectangle(Brushes.Black, x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                    bmpGraphic.FillRectangle(Brushes.Black, (x + 1) * (cellSize + 1) - 1, (y + 1) * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                                }
                            }
                        }
                    }
                }
            }
            pictureBox.Image = bmp;
        }

        void select_grain(object sender, MouseEventArgs mea)
        {
            int g;
            if (mea.Button == MouseButtons.Left)
            {
                clicked++;
                Console.WriteLine("X position = " + mea.X.ToString() + "\n" + "Y position = " + mea.Y.ToString());
                g = grid[mea.Y / 5, mea.X / 5];
                Console.WriteLine("g:" + g);
                if (clicked == 0)
                    choosenGrains.Add(g);
                else
                    if (!choosenGrains.Contains(g))
                    choosenGrains.Add(g);
            }

            for (int j = 0; j < choosenGrains.Count; j++)
                Console.WriteLine("grain: " + (int)choosenGrains[j] + " ");
        }

        void clear_space(object sender, EventArgs e)
        {
            colouring = false;
            clear = true;
            DrawGrid(bmpGraphic);
            draw_boundaries(bmpGraphic);

            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                    grid[y, x] = 0;

        }

        void generate_substructure(object sender, EventArgs e)
        {
            substructure = true;
            if (substructureCombo.Text == "substructure")
                substructureCondition = 1;
            else if (substructureCombo.Text == "dual phase")
                substructureCondition = 2;

            if (choosenGrains.Count > 0)
            {
                DrawGrid(bmpGraphic);
                for (int i = 0; i < choosenGrains.Count; i++)
                {
                    for (int y = 0; y < cellAmount; y++)
                        for (int x = 0; x < cellAmount; x++)
                        {
                            if (grid[y, x] == (int)choosenGrains[i] && substructureCombo.Text == "substructure")
                                phase[y, x] = 1;
                            if (grid[y, x] == (int)choosenGrains[i] && substructureCombo.Text == "dual phase")
                                phase[y, x] = 2;
                        }
                }
                grainsAmount++;
                leave_substructure();
            }
        }

        void leave_substructure()
        {
            DrawGrid(bmpGraphic);
            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                    if (phase[y, x] == 0)
                        grid[y, x] = 0;
            monte = false;
            draw_substructure(bmpGraphic);
        }

        void draw_substructure(Graphics bmpGraphic)
        {
            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                {
                    if (phase[y, x] == 1)
                    {
                        colorInt = 16777215 - (grid[y, x] * 109000);
                        colorHex = colorInt.ToString("X");
                        Color color = Color.FromArgb(255,
                                        int.Parse(colorHex.Substring(0, 2), NumberStyles.HexNumber),
                                        int.Parse(colorHex.Substring(2, 2), NumberStyles.HexNumber),
                                        int.Parse(colorHex.Substring(4, 2), NumberStyles.HexNumber));
                        bmpGraphic.FillRectangle(new SolidBrush(color), x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                    }
                    else if (phase[y, x] == 2)
                    {
                        bmpGraphic.FillRectangle(new SolidBrush(Color.FromArgb(23, 240, 213)), x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);

                    }
                }

            pictureBox.Image = bmp;
        }

        void add_inclusions(object sender, EventArgs e)
        {
            inclusionAmount = Convert.ToInt32(inclusionAmountTextBox.Text);
            inclusionSize = Convert.ToInt32(inclusionSizeTextBox.Text);
            running = false;
            if (inclusionTypeCombo.Text == "square")
                inclusionCondition = 1;
            else if (inclusionTypeCombo.Text == "circular")
                inclusionCondition = 2;

            locate_inclusion();
        }

        void locate_inclusion()
        {
            if (previousAmount > 0)
                Array.Clear(inclusions, 0, 2 * previousAmount);

            inclusions = new int[inclusionAmount, 2];

            inclusion = true;
            int yr, xr;
            bool repeated = false;
            inclusions[0, 0] = rand.Next(cellAmount);
            inclusions[0, 1] = rand.Next(cellAmount);
            for (int i = 1, j = i; i < inclusionAmount; i++)
            {
                repeated = false;
                yr = rand.Next(cellAmount);
                xr = rand.Next(cellAmount);
                while (j >= 0)
                {
                    if (inclusions[i, 0] == yr && inclusions[i, 1] == xr)
                    {
                        repeated = true;
                        i--;
                        break;
                    }
                    j--;
                }
                if (repeated != true)
                {
                    inclusions[i, 0] = yr;
                    inclusions[i, 1] = xr;
                }
            }

            draw_image();
        }

        void exportToFile(object sender, EventArgs e)
        {
            if (czyWypelniona == 0)
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\Kasia\source\repos\WindowsFormsApp1\WindowsFormsApp1\exportedData.txt"))
                {
                    file.WriteLine(cellAmount + "\t" + cellAmount + "\t" + grainsAmount + "\t" + phaseAmount);
                    for (int y = 0; y < cellAmount; y++)
                        for (int x = 0; x < cellAmount; x++)
                            file.WriteLine(y + "\t" + x + "\t" + grid[y, x] + "\t" + phase[y, x]);
                }

                pictureBox.Image.Save(@"C:\Users\Kasia\source\repos\WindowsFormsApp1\WindowsFormsApp1\exportedBmp.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            }
        }

        void importFromFile(object sender, EventArgs e)
        {
            if (!running)
            {
                import = true;
                czyWypelniona = -1;
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Kasia\source\repos\WindowsFormsApp1\WindowsFormsApp1\dataToImport.txt");
                string[] array = lines[0].Split();
                cellAmount = Int32.Parse(array[0]);
                cellAmount = Int32.Parse(array[1]);
                grainsAmount = Int32.Parse(array[2]);
                phaseAmount = Int32.Parse(array[3]);

                for (int y = 0; y < cellAmount; y++)
                    for (int x = 0; x < cellAmount; x++)
                        grid[y, x] = 0;

                for (int str = 1; str < lines.Length; str++)
                {
                    array = lines[str].Split();
                    grid[Int32.Parse(array[0]), Int32.Parse(array[1])] = Int32.Parse(array[2]);
                    phase[Int32.Parse(array[0]), Int32.Parse(array[1])] = Int32.Parse(array[3]);
                }

                draw_image();
            }
        }


        /*----------------------------------------------------- MONTE CARLO ----------------------------------------------------------------*/

        void initMonte(object sender, EventArgs e)
        {
            int value=1, i=0;
            if (amountTextBox.Text != null)
                grainsAmount = Convert.ToInt32(amountTextBox.Text);

            if (energyTextBox.Text != null)
                J_energy = Convert.ToDouble(energyTextBox.Text);

            if (boundaryCombo.Text == "periodic")
                boundaryCondition = 1;
            else if (boundaryCombo.Text == "absorbing")
                boundaryCondition = 2;

            energy = new int[cellAmount, cellAmount];
            monte = true;
            reset = false;
            iterationNumerPrevious = 0;

            if(choosenGrains.Count>0)
                while (i < grainsAmount)
                {
                    if (!choosenGrains.Contains(value))
                    {
                        monteColors.Add(value);
                        i++;
                    }
                    value++;
                }

            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                {
                    energy[y, x] = 0;
                    if (choosenGrains.Count > 0)
                    {
                        if (phase[y, x] == 0)
                            grid[y, x] = (int)monteColors[rand.Next(grainsAmount)];
                    }
                    else
                        grid[y, x] = rand.Next(1,grainsAmount);
                }
           
            iteration = 0;
            draw_image();
            
        }

        void monteByIteration(object sender, EventArgs e)
        {
            if (iterationTextBox.Text != null)
            {
                iterationNumber = Convert.ToInt32(iterationTextBox.Text);
                iterationNumber = iterationNumber - iterationNumerPrevious;
                iterationNumerPrevious = Convert.ToInt32(iterationTextBox.Text);
            }

            int i = 0;
            while (i < iterationNumber)
            {
                i++;
                updateMonte();
            }

            draw_image();

        }

        void monteCarlo(object sender, EventArgs e)
        {
            monte_growth = new Thread(run);
            monte_growth.Start();
        }

        void updateMonte()
        {
            double energy0;
            int state0;
            iteration++;

            for (int y = 0; y < cellAmount; y++)
               for (int x = 0; x < cellAmount; x++)
                   newGrid[y, x] = grid[y, x];
            
            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                {
                    if (phase[y, x] == 0)
                    {
                        energy0 = J_energy * checkEnergy(y, x);

                        state0 = grid[y, x];
                        grid[y, x] = getNeighbour(y, x);

                        if (J_energy * checkEnergy(y, x) > energy0)
                        {
                            grid[y, x] = state0;
                            newGrid[y, x] = grid[y, x];
                        }
                    }
                }
            if(iteration%100 ==0)
               Console.WriteLine(iteration);
        }
       

        int checkEnergy(int y, int x)
        {
            energy[y, x] = 0;
            newGrid[y, x] = grid[y, x];


                if (x != cellAmount - 1 && newGrid[y, x] != newGrid[y, x + 1] && phase[y, x + 1] == 0)
                    energy[y, x]++;
                if (y != cellAmount - 1 && newGrid[y, x] != newGrid[y + 1, x] && phase[y + 1, x] == 0)
                    energy[y, x]++;
                if (x != 0 && newGrid[y, x] != newGrid[y, x - 1] && phase[y, x - 1] == 0)
                    energy[y, x]++;
                if (y != 0 && newGrid[y, x] != newGrid[y - 1, x] && phase[y - 1, x] == 0)
                    energy[y, x]++;
                if (y != 0 && x != 0 && newGrid[y, x] != newGrid[y - 1, x - 1] && phase[y - 1, x - 1] == 0)
                    energy[y, x]++;
                if (y != 0 && x != cellAmount - 1 && newGrid[y, x] != newGrid[y - 1, x + 1] && phase[y - 1, x + 1] == 0)
                    energy[y, x]++;
                if (x != 0 && y != cellAmount - 1 && newGrid[y, x] != newGrid[y + 1, x - 1] && phase[y + 1, x - 1] == 0)
                    energy[y, x]++;
                if (x != cellAmount - 1 && y != cellAmount - 1 && newGrid[y, x] != newGrid[y + 1, x + 1] && phase[y + 1, x + 1] == 0)
                    energy[y, x]++;
            
            if(boundaryCondition == 1)
            {
                if (x == cellAmount - 1 && newGrid[y, x] != newGrid[y, 0] && phase[y, 0] == 0)
                    energy[y, x]++;
                if (y == cellAmount - 1 && newGrid[y, x] != newGrid[0, x] && phase[0, x] == 0)
                    energy[y, x]++;
                if (x == 0 && newGrid[y, x] != newGrid[y, cellAmount - 1] && phase[y, cellAmount - 1] == 0)
                    energy[y, x]++;
                if (y == 0 && newGrid[y, x] != newGrid[cellAmount - 1, x] && phase[cellAmount - 1, x] == 0)
                    energy[y, x]++;
                if (y == 0 && x == 0 && newGrid[y, x] != newGrid[cellAmount - 1, cellAmount - 1] && phase[cellAmount - 1, cellAmount - 1] == 0)
                    energy[y, x]++;
                if (y == 0 && x == cellAmount - 1 && newGrid[y, x] != newGrid[cellAmount - 1, 0] && phase[cellAmount - 1, 0] == 0)
                    energy[y, x]++;
                if (x == 0 && y == cellAmount - 1 && newGrid[y, x] != newGrid[0, cellAmount - 1] && phase[0, cellAmount - 1] == 0)
                    energy[y, x]++;
                if (x == cellAmount - 1 && y == cellAmount - 1 && newGrid[y, x] != newGrid[0, 0] && phase[0, 0] == 0)
                    energy[y, x]++;
            }

            return energy[y, x];
        }

        int getNeighbour(int y, int x)
        {
            int n = 0, s;
            do
            {
                s = rand.Next(1, 8);
                if (s == 1 && y != 0 && x != 0 && phase[y - 1, x - 1] == 0)
                    n = newGrid[y - 1, x - 1];
                else if (s == 2 && y != 0 && phase[y - 1, x] == 0)
                    n = newGrid[y - 1, x];
                else if (s == 3 && y != 0 && x != cellAmount - 1 && phase[y - 1, x + 1] == 0)
                    n = newGrid[y - 1, x + 1];
                else if (s == 4 && x != cellAmount - 1 && phase[y, x + 1] == 0)
                    n = newGrid[y, x + 1];
                else if (s == 5 && y != cellAmount - 1 && x != cellAmount - 1 && phase[y + 1, x + 1] == 0)
                    n = newGrid[y + 1, x + 1];
                else if (s == 6 && y != cellAmount - 1 && phase[y + 1, x] == 0)
                    n = newGrid[y + 1, x];
                else if (s == 7 && y != cellAmount - 1 && x != 0 && phase[y + 1, x - 1] == 0)
                    n = newGrid[y + 1, x - 1];
                else if (s == 8 && x != 0 && phase[y, x - 1] == 0)
                    n = newGrid[y, x - 1];

                if (boundaryCondition == 1)
                {
                    if (s == 1 && y == 0 && x == 0 && phase[cellAmount - 1, cellAmount - 1] == 0)
                        n = newGrid[cellAmount - 1, cellAmount - 1];
                    else if (s == 2 && y == 0 && phase[cellAmount - 1, x] == 0)
                        n = newGrid[cellAmount - 1, x];
                    else if (s == 3 && y == 0 && x == cellAmount - 1 && phase[cellAmount - 1, 0] == 0)
                        n = newGrid[cellAmount - 1, 0];
                    else if (s == 4 && x == cellAmount - 1 && phase[y, 0] == 0)
                        n = newGrid[y, 0];
                    else if (s == 5 && y == cellAmount - 1 && x == cellAmount - 1 && phase[0, 0] == 0)
                        n = newGrid[0, 0];
                    else if (s == 6 && y == cellAmount - 1 && phase[0, x] == 0)
                        n = newGrid[0, x];
                    else if (s == 7 && y == cellAmount - 1 && x == 0 && phase[0, cellAmount - 1] == 0)
                        n = newGrid[0, cellAmount - 1];
                    else if (s == 8 && x == 0 && phase[y, cellAmount - 1] == 0)
                        n = newGrid[y, cellAmount - 1];
                }

            } while (n == 0);

            return n;
        }

        void energyDistribution(object sender, EventArgs e)
        {
            int H = 0;
            if (distributionTypeCombo.Text == "homogenous")
                distributionCondition = 1;
            else if (distributionTypeCombo.Text == "heterogenous")
                distributionCondition = 2;
           

            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                {
                    if (distributionCondition == 1)
                        energySRX[y, x] = 5;
                    else if(distributionCondition == 2)
                    {
                        if (x != cellAmount - 1 && grid[y, x] != grid[y, x + 1])
                            energySRX[y, x] = 7;
                        else if (y != cellAmount - 1 && grid[y, x] != grid[y + 1, x])
                            energySRX[y, x] = 7;
                        else
                            energySRX[y, x] = 2;
                    }
                }
            draw_energySRX(bmpGraphic);

        }

        void draw_energySRX(Graphics bmpGraphic)
        {
            clearingSRX = false;
            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                {
                    if (energySRX[y, x] == 5)
                        bmpGraphic.FillRectangle(new SolidBrush(Color.FromArgb(54, 119, 252)), x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                    else if(energySRX[y, x] == 2)
                        bmpGraphic.FillRectangle(new SolidBrush(Color.FromArgb(0, 98, 211)), x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                    else if (energySRX[y, x] == 7)
                        bmpGraphic.FillRectangle(new SolidBrush(Color.FromArgb(231, 229, 92)), x * (cellSize + 1) - 1, y * (cellSize + 1) - 1, cellSize + 2, cellSize + 2);
                }

            pictureBox.Image = bmp;
        }

       void clearDistribution(object sender, EventArgs e)
        {
            clearingSRX = true;
            for (int y = 0; y < cellAmount; y++)
                for (int x = 0; x < cellAmount; x++)
                        energySRX[y, x] = 0;

            draw_image();
        }

    }
}