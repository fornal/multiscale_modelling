using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label mainLabel, amountLabel, neighbourLabel, boundaryLabel, positionLabel,
            inclusionLabel, inclusionAmountLabel, inclusionSizeLabel, inclusionTypeLabel, grainBoundaryLabel, grainBoundarySizeLabel, grainBoundaryTypeLabel,
            structureLabel, substructureLabel, monteLabel, energyLabel, iterationLabel, distributionTypeLabel, insideEnergyLabel, edgeEnergyLabel;
        private System.Windows.Forms.TextBox amountTextBox, inclusionAmountTextBox, inclusionSizeTextBox, grainBoundarySizeTextBox, energyTextBox, iterationTextBox,
            insideEnergyTextBox, edgeEnergyTextBox;
        private System.Windows.Forms.Button inclusionButton, startButton, resetButton, importButton, exportButton, colourBoundaryButton, 
            clearSpaceBoundaryButton, substructureButton, monteStructureButton, monteSimulationButton, monteButton, energyDistributionButton, clearDistributionButton;
        private System.Windows.Forms.ComboBox neighbourCombo, boundaryCombo, positionCombo, inclusionTypeCombo, grainBoundaryTypeCombo, substructureCombo,
            distributionTypeCombo;


        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
    private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.mainLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.neighbourLabel = new System.Windows.Forms.Label();
            this.neighbourCombo = new System.Windows.Forms.ComboBox();
            this.boundaryLabel = new System.Windows.Forms.Label();
            this.boundaryCombo = new System.Windows.Forms.ComboBox();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionCombo = new System.Windows.Forms.ComboBox();
            this.grainBoundaryLabel = new System.Windows.Forms.Label();
            this.grainBoundarySizeLabel = new System.Windows.Forms.Label();
            this.grainBoundarySizeTextBox = new System.Windows.Forms.TextBox();
            this.grainBoundaryTypeLabel = new System.Windows.Forms.Label();
            this.grainBoundaryTypeCombo = new System.Windows.Forms.ComboBox();
            this.colourBoundaryButton = new System.Windows.Forms.Button();
            this.clearSpaceBoundaryButton = new System.Windows.Forms.Button();
            this.structureLabel = new System.Windows.Forms.Label();
            this.substructureLabel = new System.Windows.Forms.Label();
            this.substructureCombo = new System.Windows.Forms.ComboBox();
            this.substructureButton = new System.Windows.Forms.Button();
            this.inclusionLabel = new System.Windows.Forms.Label();
            this.inclusionAmountLabel = new System.Windows.Forms.Label();
            this.inclusionAmountTextBox = new System.Windows.Forms.TextBox();
            this.inclusionSizeLabel = new System.Windows.Forms.Label();
            this.inclusionSizeTextBox = new System.Windows.Forms.TextBox();
            this.inclusionTypeLabel = new System.Windows.Forms.Label();
            this.inclusionTypeCombo = new System.Windows.Forms.ComboBox();
            this.inclusionButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.monteLabel = new System.Windows.Forms.Label();
            this.energyLabel = new System.Windows.Forms.Label();
            this.energyTextBox = new System.Windows.Forms.TextBox();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.iterationTextBox = new System.Windows.Forms.TextBox();
            this.monteStructureButton = new System.Windows.Forms.Button();
            this.monteSimulationButton = new System.Windows.Forms.Button();
            this.monteButton = new System.Windows.Forms.Button();
            this.distributionTypeLabel = new System.Windows.Forms.Label();
            this.distributionTypeCombo = new System.Windows.Forms.ComboBox();
            this.insideEnergyLabel = new System.Windows.Forms.Label();
            this.insideEnergyTextBox = new System.Windows.Forms.TextBox();
            this.edgeEnergyLabel = new System.Windows.Forms.Label();
            this.edgeEnergyTextBox = new System.Windows.Forms.TextBox();
            this.energyDistributionButton = new System.Windows.Forms.Button();
            this.clearDistributionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(569, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(661, 661);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.select_grain);
            // 
            // mainLabel
            // 
            this.mainLabel.Location = new System.Drawing.Point(237, 20);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(94, 20);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "GRAIN GROWTH";
            // 
            // amountLabel
            // 
            this.amountLabel.Location = new System.Drawing.Point(5, 60);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(123, 20);
            this.amountLabel.TabIndex = 0;
            this.amountLabel.Text = "Amount of grains:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(134, 57);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(120, 23);
            this.amountTextBox.TabIndex = 0;
            this.amountTextBox.TabStop = false;
            // 
            // neighbourLabel
            // 
            this.neighbourLabel.Location = new System.Drawing.Point(286, 60);
            this.neighbourLabel.Name = "neighbourLabel";
            this.neighbourLabel.Size = new System.Drawing.Size(135, 18);
            this.neighbourLabel.TabIndex = 1;
            this.neighbourLabel.Text = "Type of neighbourhood:";
            // 
            // neighbourCombo
            // 
            this.neighbourCombo.Items.AddRange(new object[] {
            "von Neumann",
            "Moore"});
            this.neighbourCombo.Location = new System.Drawing.Point(434, 57);
            this.neighbourCombo.Name = "neighbourCombo";
            this.neighbourCombo.Size = new System.Drawing.Size(120, 21);
            this.neighbourCombo.TabIndex = 2;
            this.neighbourCombo.Text = "von Neumann";
            // 
            // boundaryLabel
            // 
            this.boundaryLabel.Location = new System.Drawing.Point(286, 87);
            this.boundaryLabel.Name = "boundaryLabel";
            this.boundaryLabel.Size = new System.Drawing.Size(135, 20);
            this.boundaryLabel.TabIndex = 2;
            this.boundaryLabel.Text = "Boundary conditions:";
            // 
            // boundaryCombo
            // 
            this.boundaryCombo.Items.AddRange(new object[] {
            "periodic",
            "absorbing"});
            this.boundaryCombo.Location = new System.Drawing.Point(434, 84);
            this.boundaryCombo.Name = "boundaryCombo";
            this.boundaryCombo.Size = new System.Drawing.Size(120, 21);
            this.boundaryCombo.TabIndex = 3;
            this.boundaryCombo.Text = "periodic";
            // 
            // positionLabel
            // 
            this.positionLabel.Location = new System.Drawing.Point(286, 111);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(135, 21);
            this.positionLabel.TabIndex = 3;
            this.positionLabel.Text = "Grains position:";
            // 
            // positionCombo
            // 
            this.positionCombo.Items.AddRange(new object[] {
            "randomly",
            "regular"});
            this.positionCombo.Location = new System.Drawing.Point(434, 111);
            this.positionCombo.Name = "positionCombo";
            this.positionCombo.Size = new System.Drawing.Size(120, 21);
            this.positionCombo.TabIndex = 4;
            this.positionCombo.Text = "randomly";
            // 
            // grainBoundaryLabel
            // 
            this.grainBoundaryLabel.Location = new System.Drawing.Point(370, 191);
            this.grainBoundaryLabel.Name = "grainBoundaryLabel";
            this.grainBoundaryLabel.Size = new System.Drawing.Size(114, 20);
            this.grainBoundaryLabel.TabIndex = 5;
            this.grainBoundaryLabel.Text = "Boundary colouring";
            // 
            // grainBoundarySizeLabel
            // 
            this.grainBoundarySizeLabel.Location = new System.Drawing.Point(277, 217);
            this.grainBoundarySizeLabel.Name = "grainBoundarySizeLabel";
            this.grainBoundarySizeLabel.Size = new System.Drawing.Size(157, 20);
            this.grainBoundarySizeLabel.TabIndex = 5;
            this.grainBoundarySizeLabel.Text = "Size of coloured boundaries:";
            // 
            // grainBoundarySizeTextBox
            // 
            this.grainBoundarySizeTextBox.Location = new System.Drawing.Point(434, 214);
            this.grainBoundarySizeTextBox.Name = "grainBoundarySizeTextBox";
            this.grainBoundarySizeTextBox.Size = new System.Drawing.Size(120, 23);
            this.grainBoundarySizeTextBox.TabIndex = 5;
            this.grainBoundarySizeTextBox.Text = "1";
            // 
            // grainBoundaryTypeLabel
            // 
            this.grainBoundaryTypeLabel.Location = new System.Drawing.Point(277, 246);
            this.grainBoundaryTypeLabel.Name = "grainBoundaryTypeLabel";
            this.grainBoundaryTypeLabel.Size = new System.Drawing.Size(155, 20);
            this.grainBoundaryTypeLabel.TabIndex = 8;
            this.grainBoundaryTypeLabel.Text = "Amount of selected grains:";
            // 
            // grainBoundaryTypeCombo
            // 
            this.grainBoundaryTypeCombo.DropDownHeight = 130;
            this.grainBoundaryTypeCombo.IntegralHeight = false;
            this.grainBoundaryTypeCombo.ItemHeight = 13;
            this.grainBoundaryTypeCombo.Items.AddRange(new object[] {
            "all grains",
            "choosen grains"});
            this.grainBoundaryTypeCombo.Location = new System.Drawing.Point(434, 243);
            this.grainBoundaryTypeCombo.Name = "grainBoundaryTypeCombo";
            this.grainBoundaryTypeCombo.Size = new System.Drawing.Size(120, 21);
            this.grainBoundaryTypeCombo.TabIndex = 9;
            this.grainBoundaryTypeCombo.Text = "all grains";
            // 
            // colourBoundaryButton
            // 
            this.colourBoundaryButton.Location = new System.Drawing.Point(268, 299);
            this.colourBoundaryButton.Name = "colourBoundaryButton";
            this.colourBoundaryButton.Size = new System.Drawing.Size(140, 30);
            this.colourBoundaryButton.TabIndex = 12;
            this.colourBoundaryButton.Text = "Colour boundaries";
            this.colourBoundaryButton.Click += new System.EventHandler(this.add_boundaries);
            // 
            // clearSpaceBoundaryButton
            // 
            this.clearSpaceBoundaryButton.Location = new System.Drawing.Point(414, 299);
            this.clearSpaceBoundaryButton.Name = "clearSpaceBoundaryButton";
            this.clearSpaceBoundaryButton.Size = new System.Drawing.Size(140, 30);
            this.clearSpaceBoundaryButton.TabIndex = 12;
            this.clearSpaceBoundaryButton.Text = "Clear space";
            this.clearSpaceBoundaryButton.Click += new System.EventHandler(this.clear_space);
            // 
            // structureLabel
            // 
            this.structureLabel.Location = new System.Drawing.Point(265, 348);
            this.structureLabel.Name = "structureLabel";
            this.structureLabel.Size = new System.Drawing.Size(56, 20);
            this.structureLabel.TabIndex = 5;
            this.structureLabel.Text = "Structure";
            // 
            // substructureLabel
            // 
            this.substructureLabel.Location = new System.Drawing.Point(75, 380);
            this.substructureLabel.Name = "substructureLabel";
            this.substructureLabel.Size = new System.Drawing.Size(107, 20);
            this.substructureLabel.TabIndex = 5;
            this.substructureLabel.Text = "Type of structure: ";
            // 
            // substructureCombo
            // 
            this.substructureCombo.Items.AddRange(new object[] {
            "substructure",
            "dual phase"});
            this.substructureCombo.Location = new System.Drawing.Point(201, 377);
            this.substructureCombo.Name = "substructureCombo";
            this.substructureCombo.Size = new System.Drawing.Size(120, 21);
            this.substructureCombo.TabIndex = 4;
            this.substructureCombo.Text = "substructure";
            // 
            // substructureButton
            // 
            this.substructureButton.Location = new System.Drawing.Point(373, 371);
            this.substructureButton.Name = "substructureButton";
            this.substructureButton.Size = new System.Drawing.Size(150, 30);
            this.substructureButton.TabIndex = 12;
            this.substructureButton.Text = "Generate structure";
            this.substructureButton.Click += new System.EventHandler(this.generate_substructure);
            // 
            // inclusionLabel
            // 
            this.inclusionLabel.Location = new System.Drawing.Point(106, 191);
            this.inclusionLabel.Name = "inclusionLabel";
            this.inclusionLabel.Size = new System.Drawing.Size(66, 20);
            this.inclusionLabel.TabIndex = 5;
            this.inclusionLabel.Text = "Inclusions";
            // 
            // inclusionAmountLabel
            // 
            this.inclusionAmountLabel.Location = new System.Drawing.Point(5, 217);
            this.inclusionAmountLabel.Name = "inclusionAmountLabel";
            this.inclusionAmountLabel.Size = new System.Drawing.Size(123, 20);
            this.inclusionAmountLabel.TabIndex = 4;
            this.inclusionAmountLabel.Text = "Amount of inclusions:";
            // 
            // inclusionAmountTextBox
            // 
            this.inclusionAmountTextBox.Location = new System.Drawing.Point(134, 214);
            this.inclusionAmountTextBox.Name = "inclusionAmountTextBox";
            this.inclusionAmountTextBox.Size = new System.Drawing.Size(120, 23);
            this.inclusionAmountTextBox.TabIndex = 5;
            // 
            // inclusionSizeLabel
            // 
            this.inclusionSizeLabel.Location = new System.Drawing.Point(5, 246);
            this.inclusionSizeLabel.Name = "inclusionSizeLabel";
            this.inclusionSizeLabel.Size = new System.Drawing.Size(123, 20);
            this.inclusionSizeLabel.TabIndex = 6;
            this.inclusionSizeLabel.Text = "Size of inclusions:";
            // 
            // inclusionSizeTextBox
            // 
            this.inclusionSizeTextBox.Location = new System.Drawing.Point(134, 243);
            this.inclusionSizeTextBox.Name = "inclusionSizeTextBox";
            this.inclusionSizeTextBox.Size = new System.Drawing.Size(120, 23);
            this.inclusionSizeTextBox.TabIndex = 7;
            // 
            // inclusionTypeLabel
            // 
            this.inclusionTypeLabel.Location = new System.Drawing.Point(5, 275);
            this.inclusionTypeLabel.Name = "inclusionTypeLabel";
            this.inclusionTypeLabel.Size = new System.Drawing.Size(123, 20);
            this.inclusionTypeLabel.TabIndex = 8;
            this.inclusionTypeLabel.Text = "Type of inclusions:";
            // 
            // inclusionTypeCombo
            // 
            this.inclusionTypeCombo.DropDownHeight = 130;
            this.inclusionTypeCombo.IntegralHeight = false;
            this.inclusionTypeCombo.ItemHeight = 13;
            this.inclusionTypeCombo.Items.AddRange(new object[] {
            "square",
            "circular"});
            this.inclusionTypeCombo.Location = new System.Drawing.Point(134, 272);
            this.inclusionTypeCombo.Name = "inclusionTypeCombo";
            this.inclusionTypeCombo.Size = new System.Drawing.Size(120, 21);
            this.inclusionTypeCombo.TabIndex = 9;
            this.inclusionTypeCombo.Text = "square";
            // 
            // inclusionButton
            // 
            this.inclusionButton.Location = new System.Drawing.Point(56, 299);
            this.inclusionButton.Name = "inclusionButton";
            this.inclusionButton.Size = new System.Drawing.Size(150, 30);
            this.inclusionButton.TabIndex = 9;
            this.inclusionButton.Text = "Add inclusions";
            this.inclusionButton.Click += new System.EventHandler(this.add_inclusions);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(334, 138);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 30);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Start grain growth";
            this.startButton.Click += new System.EventHandler(this.start_growth);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(56, 138);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(150, 30);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.reset_board);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(299, 651);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(150, 30);
            this.importButton.TabIndex = 12;
            this.importButton.Text = "Import from file";
            this.importButton.Click += new System.EventHandler(this.importFromFile);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(104, 651);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(150, 30);
            this.exportButton.TabIndex = 13;
            this.exportButton.Text = "Export to file";
            this.exportButton.Click += new System.EventHandler(this.exportToFile);
            // 
            // monteLabel
            // 
            this.monteLabel.Location = new System.Drawing.Point(88, 427);
            this.monteLabel.Name = "monteLabel";
            this.monteLabel.Size = new System.Drawing.Size(127, 20);
            this.monteLabel.TabIndex = 5;
            this.monteLabel.Text = "MONTE CARLO GRAIN GROWTH";
            // 
            // energyLabel
            // 
            this.energyLabel.Location = new System.Drawing.Point(5, 453);
            this.energyLabel.Name = "energyLabel";
            this.energyLabel.Size = new System.Drawing.Size(132, 20);
            this.energyLabel.TabIndex = 5;
            this.energyLabel.Text = "Grain boundary energy:";
            // 
            // energyTextBox
            // 
            this.energyTextBox.Location = new System.Drawing.Point(154, 450);
            this.energyTextBox.Name = "energyTextBox";
            this.energyTextBox.Size = new System.Drawing.Size(120, 23);
            this.energyTextBox.TabIndex = 5;
            this.energyTextBox.Text = "1";
            // 
            // iterationLabel
            // 
            this.iterationLabel.Location = new System.Drawing.Point(5, 482);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(128, 20);
            this.iterationLabel.TabIndex = 5;
            this.iterationLabel.Text = "Number of iterations:";
            // 
            // iterationTextBox
            // 
            this.iterationTextBox.Location = new System.Drawing.Point(154, 479);
            this.iterationTextBox.Name = "iterationTextBox";
            this.iterationTextBox.Size = new System.Drawing.Size(120, 23);
            this.iterationTextBox.TabIndex = 5;
            // 
            // monteStructureButton
            // 
            this.monteStructureButton.Location = new System.Drawing.Point(8, 515);
            this.monteStructureButton.Name = "monteStructureButton";
            this.monteStructureButton.Size = new System.Drawing.Size(130, 30);
            this.monteStructureButton.TabIndex = 13;
            this.monteStructureButton.Text = "Create structure";
            this.monteStructureButton.Click += new System.EventHandler(this.initMonte);
            // 
            // monteSimulationButton
            // 
            this.monteSimulationButton.Location = new System.Drawing.Point(144, 515);
            this.monteSimulationButton.Name = "monteSimulationButton";
            this.monteSimulationButton.Size = new System.Drawing.Size(130, 30);
            this.monteSimulationButton.TabIndex = 13;
            this.monteSimulationButton.Text = "Monte Carlo by steps";
            this.monteSimulationButton.Click += new System.EventHandler(this.monteByIteration);
            // 
            // monteButton
            // 
            this.monteButton.Location = new System.Drawing.Point(56, 551);
            this.monteButton.Name = "monteButton";
            this.monteButton.Size = new System.Drawing.Size(170, 30);
            this.monteButton.TabIndex = 13;
            this.monteButton.Text = "Full Monte Carlo Simulation";
            this.monteButton.Click += new System.EventHandler(this.monteCarlo);
            // 
            // distributionTypeLabel
            // 
            this.distributionTypeLabel.Location = new System.Drawing.Point(307, 450);
            this.distributionTypeLabel.Name = "distributionTypeLabel";
            this.distributionTypeLabel.Size = new System.Drawing.Size(114, 20);
            this.distributionTypeLabel.TabIndex = 5;
            this.distributionTypeLabel.Text = "Energy distribution:";
            // 
            // distributionTypeCombo
            // 
            this.distributionTypeCombo.DropDownHeight = 130;
            this.distributionTypeCombo.IntegralHeight = false;
            this.distributionTypeCombo.ItemHeight = 13;
            this.distributionTypeCombo.Items.AddRange(new object[] {
            "homogenous",
            "heterogenous"});
            this.distributionTypeCombo.Location = new System.Drawing.Point(434, 447);
            this.distributionTypeCombo.Name = "distributionTypeCombo";
            this.distributionTypeCombo.Size = new System.Drawing.Size(120, 21);
            this.distributionTypeCombo.TabIndex = 9;
            this.distributionTypeCombo.Text = "homogenous";
            // 
            // insideEnergyLabel
            // 
            this.insideEnergyLabel.Location = new System.Drawing.Point(307, 477);
            this.insideEnergyLabel.Name = "insideEnergyLabel";
            this.insideEnergyLabel.Size = new System.Drawing.Size(80, 20);
            this.insideEnergyLabel.TabIndex = 5;
            this.insideEnergyLabel.Text = "Energy inside:";
            // 
            // insideEnergyTextBox
            // 
            this.insideEnergyTextBox.Location = new System.Drawing.Point(434, 474);
            this.insideEnergyTextBox.Name = "insideEnergyTextBox";
            this.insideEnergyTextBox.Size = new System.Drawing.Size(120, 20);
            this.insideEnergyTextBox.TabIndex = 5;
            // 
            // edgeEnergyLabel
            // 
            this.edgeEnergyLabel.Location = new System.Drawing.Point(307, 506);
            this.edgeEnergyLabel.Name = "edgeEnergyLabel";
            this.edgeEnergyLabel.Size = new System.Drawing.Size(100, 20);
            this.edgeEnergyLabel.TabIndex = 5;
            this.edgeEnergyLabel.Text = "Energy on edges:";
            // 
            // edgeEnergyTextBox
            // 
            this.edgeEnergyTextBox.Location = new System.Drawing.Point(434, 503);
            this.edgeEnergyTextBox.Name = "edgeEnergyTextBox";
            this.edgeEnergyTextBox.Size = new System.Drawing.Size(120, 20);
            this.edgeEnergyTextBox.TabIndex = 5;
            // 
            // energyDistributionButton
            // 
            this.energyDistributionButton.Location = new System.Drawing.Point(373, 482);
            this.energyDistributionButton.Name = "energyDistributionButton";
            this.energyDistributionButton.Size = new System.Drawing.Size(140, 30);
            this.energyDistributionButton.TabIndex = 13;
            this.energyDistributionButton.Text = "Distribute energy";
            this.energyDistributionButton.Click += new System.EventHandler(this.energyDistribution);
            // 
            // clearDistributionButton
            // 
            this.clearDistributionButton.Location = new System.Drawing.Point(373, 518);
            this.clearDistributionButton.Name = "clearDistributionButton";
            this.clearDistributionButton.Size = new System.Drawing.Size(140, 30);
            this.clearDistributionButton.TabIndex = 13;
            this.clearDistributionButton.Text = "Clear distribution";
            this.clearDistributionButton.Click += new System.EventHandler(this.clearDistribution);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 700);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.neighbourLabel);
            this.Controls.Add(this.neighbourCombo);
            this.Controls.Add(this.boundaryLabel);
            this.Controls.Add(this.boundaryCombo);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.positionCombo);
            this.Controls.Add(this.grainBoundaryLabel);
            this.Controls.Add(this.grainBoundarySizeLabel);
            this.Controls.Add(this.grainBoundarySizeTextBox);
            this.Controls.Add(this.grainBoundaryTypeLabel);
            this.Controls.Add(this.grainBoundaryTypeCombo);
            this.Controls.Add(this.colourBoundaryButton);
            this.Controls.Add(this.clearSpaceBoundaryButton);
            this.Controls.Add(this.structureLabel);
            this.Controls.Add(this.substructureLabel);
            this.Controls.Add(this.substructureCombo);
            this.Controls.Add(this.substructureButton);
            this.Controls.Add(this.inclusionLabel);
            this.Controls.Add(this.inclusionAmountLabel);
            this.Controls.Add(this.inclusionAmountTextBox);
            this.Controls.Add(this.inclusionSizeLabel);
            this.Controls.Add(this.inclusionSizeTextBox);
            this.Controls.Add(this.inclusionTypeLabel);
            this.Controls.Add(this.inclusionTypeCombo);
            this.Controls.Add(this.inclusionButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.monteLabel);
            this.Controls.Add(this.energyLabel);
            this.Controls.Add(this.energyTextBox);
            this.Controls.Add(this.iterationLabel);
            this.Controls.Add(this.iterationTextBox);
            this.Controls.Add(this.monteStructureButton);
            this.Controls.Add(this.monteSimulationButton);
            this.Controls.Add(this.monteButton);
            this.Controls.Add(this.distributionTypeLabel);
            this.Controls.Add(this.distributionTypeCombo);
            this.Controls.Add(this.energyDistributionButton);
            this.Controls.Add(this.clearDistributionButton);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Malgun Gothic Semilight", 8.5F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grains growth";
            this.Load += new System.EventHandler(this.genarate_bitmap);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}

