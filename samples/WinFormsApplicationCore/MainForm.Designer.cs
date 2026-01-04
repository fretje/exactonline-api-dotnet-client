namespace WinFormsApplicationCore;

partial class MainForm
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		countItemsButton = new Button();
		outputTextBox = new TextBox();
		outputLabel = new Label();
		initializingLabel = new Label();
		SuspendLayout();
		// 
		// countItemsButton
		// 
		countItemsButton.Location = new Point(693, 12);
		countItemsButton.Name = "countItemsButton";
		countItemsButton.Size = new Size(95, 23);
		countItemsButton.TabIndex = 0;
		countItemsButton.Text = "Count Items";
		countItemsButton.UseVisualStyleBackColor = true;
		// 
		// outputTextBox
		// 
		outputTextBox.Location = new Point(12, 195);
		outputTextBox.Multiline = true;
		outputTextBox.Name = "outputTextBox";
		outputTextBox.ReadOnly = true;
		outputTextBox.ScrollBars = ScrollBars.Vertical;
		outputTextBox.Size = new Size(776, 243);
		outputTextBox.TabIndex = 1;
		// 
		// outputLabel
		// 
		outputLabel.AutoSize = true;
		outputLabel.Location = new Point(14, 170);
		outputLabel.Name = "outputLabel";
		outputLabel.Size = new Size(45, 15);
		outputLabel.TabIndex = 2;
		outputLabel.Text = "Output";
		// 
		// initializingLabel
		// 
		initializingLabel.AutoSize = true;
		initializingLabel.Location = new Point(12, 20);
		initializingLabel.Name = "initializingLabel";
		initializingLabel.Size = new Size(85, 15);
		initializingLabel.TabIndex = 3;
		initializingLabel.Text = "... Initializing ...";
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(initializingLabel);
		Controls.Add(outputLabel);
		Controls.Add(outputTextBox);
		Controls.Add(countItemsButton);
		Name = "MainForm";
		Text = "MainForm";
		Load += MainForm_Load;
		ResumeLayout(false);
		PerformLayout();

	}

	#endregion

	private Button countItemsButton;
	private TextBox outputTextBox;
	private Label outputLabel;
	private Label initializingLabel;
}
