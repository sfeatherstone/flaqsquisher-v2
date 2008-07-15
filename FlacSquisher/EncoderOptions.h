#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace FlacSquisher {

	/// <summary>
	/// Summary for EncoderOptions
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class EncoderOptions : public System::Windows::Forms::Form
	{
	public:
		EncoderOptions(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~EncoderOptions()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TabControl^  tabControl1;
	private: System::Windows::Forms::TabPage^  lametab;
	protected: 

	private: System::Windows::Forms::TabPage^  oggtab;
	private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel1;
	private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel2;
	private: System::Windows::Forms::GroupBox^  targetGroup;
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::CheckBox^  mono;
	private: System::Windows::Forms::GroupBox^  bitrateGroup;
	private: System::Windows::Forms::GroupBox^  qualityGroup;


	private: System::Windows::Forms::Button^  okButton;
	private: System::Windows::Forms::Button^  cancelButton;
	private: System::Windows::Forms::RadioButton^  qualityRadio;

	private: System::Windows::Forms::RadioButton^  bitrateRadio;
	private: System::Windows::Forms::CheckBox^  cbr;
	private: System::Windows::Forms::TrackBar^  bitrateBar;

	private: System::Windows::Forms::ComboBox^  vbrMode;
	private: System::Windows::Forms::TrackBar^  qualBar;


	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Panel^  panel3;
	private: System::Windows::Forms::Label^  lamelabel;
	private: System::Windows::Forms::Label^  lame192;
	private: System::Windows::Forms::Label^  lame320;
	private: System::Windows::Forms::Label^  lame8;
	private: System::Windows::Forms::Label^  lame64;
	private: System::Windows::Forms::Label^  lame256;
	private: System::Windows::Forms::Label^  lame128;
	private: System::Windows::Forms::Label^  lame50;
	private: System::Windows::Forms::Label^  lame100;
	private: System::Windows::Forms::Label^  lame10;









	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->tabControl1 = (gcnew System::Windows::Forms::TabControl());
			this->oggtab = (gcnew System::Windows::Forms::TabPage());
			this->tableLayoutPanel1 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->lametab = (gcnew System::Windows::Forms::TabPage());
			this->tableLayoutPanel2 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->targetGroup = (gcnew System::Windows::Forms::GroupBox());
			this->qualityRadio = (gcnew System::Windows::Forms::RadioButton());
			this->bitrateRadio = (gcnew System::Windows::Forms::RadioButton());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->mono = (gcnew System::Windows::Forms::CheckBox());
			this->bitrateGroup = (gcnew System::Windows::Forms::GroupBox());
			this->cbr = (gcnew System::Windows::Forms::CheckBox());
			this->bitrateBar = (gcnew System::Windows::Forms::TrackBar());
			this->qualityGroup = (gcnew System::Windows::Forms::GroupBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->vbrMode = (gcnew System::Windows::Forms::ComboBox());
			this->qualBar = (gcnew System::Windows::Forms::TrackBar());
			this->okButton = (gcnew System::Windows::Forms::Button());
			this->cancelButton = (gcnew System::Windows::Forms::Button());
			this->lamelabel = (gcnew System::Windows::Forms::Label());
			this->panel3 = (gcnew System::Windows::Forms::Panel());
			this->lame192 = (gcnew System::Windows::Forms::Label());
			this->lame8 = (gcnew System::Windows::Forms::Label());
			this->lame320 = (gcnew System::Windows::Forms::Label());
			this->lame64 = (gcnew System::Windows::Forms::Label());
			this->lame128 = (gcnew System::Windows::Forms::Label());
			this->lame256 = (gcnew System::Windows::Forms::Label());
			this->lame10 = (gcnew System::Windows::Forms::Label());
			this->lame100 = (gcnew System::Windows::Forms::Label());
			this->lame50 = (gcnew System::Windows::Forms::Label());
			this->tabControl1->SuspendLayout();
			this->oggtab->SuspendLayout();
			this->lametab->SuspendLayout();
			this->tableLayoutPanel2->SuspendLayout();
			this->targetGroup->SuspendLayout();
			this->panel1->SuspendLayout();
			this->bitrateGroup->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->bitrateBar))->BeginInit();
			this->qualityGroup->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->qualBar))->BeginInit();
			this->panel3->SuspendLayout();
			this->SuspendLayout();
			// 
			// tabControl1
			// 
			this->tabControl1->Controls->Add(this->oggtab);
			this->tabControl1->Controls->Add(this->lametab);
			this->tabControl1->Dock = System::Windows::Forms::DockStyle::Top;
			this->tabControl1->Location = System::Drawing::Point(0, 0);
			this->tabControl1->Multiline = true;
			this->tabControl1->Name = L"tabControl1";
			this->tabControl1->SelectedIndex = 0;
			this->tabControl1->Size = System::Drawing::Size(542, 425);
			this->tabControl1->TabIndex = 0;
			// 
			// oggtab
			// 
			this->oggtab->Controls->Add(this->tableLayoutPanel1);
			this->oggtab->Location = System::Drawing::Point(4, 22);
			this->oggtab->Name = L"oggtab";
			this->oggtab->Padding = System::Windows::Forms::Padding(3);
			this->oggtab->Size = System::Drawing::Size(534, 399);
			this->oggtab->TabIndex = 1;
			this->oggtab->Text = L"OggEnc (Ogg Vorbis)";
			this->oggtab->UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this->tableLayoutPanel1->ColumnCount = 2;
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
				50)));
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
				50)));
			this->tableLayoutPanel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->tableLayoutPanel1->Location = System::Drawing::Point(3, 3);
			this->tableLayoutPanel1->Name = L"tableLayoutPanel1";
			this->tableLayoutPanel1->RowCount = 2;
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 50)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 50)));
			this->tableLayoutPanel1->Size = System::Drawing::Size(528, 393);
			this->tableLayoutPanel1->TabIndex = 0;
			// 
			// lametab
			// 
			this->lametab->Controls->Add(this->panel3);
			this->lametab->Controls->Add(this->tableLayoutPanel2);
			this->lametab->Location = System::Drawing::Point(4, 22);
			this->lametab->Name = L"lametab";
			this->lametab->Padding = System::Windows::Forms::Padding(3);
			this->lametab->Size = System::Drawing::Size(534, 399);
			this->lametab->TabIndex = 0;
			this->lametab->Text = L"LAME (MP3)";
			this->lametab->UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this->tableLayoutPanel2->ColumnCount = 3;
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
				45.32967F)));
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
				54.67033F)));
			this->tableLayoutPanel2->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Absolute, 
				171)));
			this->tableLayoutPanel2->Controls->Add(this->targetGroup, 0, 0);
			this->tableLayoutPanel2->Controls->Add(this->panel1, 2, 0);
			this->tableLayoutPanel2->Controls->Add(this->bitrateGroup, 0, 1);
			this->tableLayoutPanel2->Controls->Add(this->qualityGroup, 0, 2);
			this->tableLayoutPanel2->Dock = System::Windows::Forms::DockStyle::Top;
			this->tableLayoutPanel2->Location = System::Drawing::Point(3, 3);
			this->tableLayoutPanel2->Name = L"tableLayoutPanel2";
			this->tableLayoutPanel2->RowCount = 3;
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 42.46575F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 57.53425F)));
			this->tableLayoutPanel2->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Absolute, 123)));
			this->tableLayoutPanel2->Size = System::Drawing::Size(528, 368);
			this->tableLayoutPanel2->TabIndex = 0;
			// 
			// targetGroup
			// 
			this->targetGroup->Controls->Add(this->qualityRadio);
			this->targetGroup->Controls->Add(this->bitrateRadio);
			this->targetGroup->Dock = System::Windows::Forms::DockStyle::Fill;
			this->targetGroup->Location = System::Drawing::Point(3, 3);
			this->targetGroup->Name = L"targetGroup";
			this->targetGroup->Size = System::Drawing::Size(155, 98);
			this->targetGroup->TabIndex = 0;
			this->targetGroup->TabStop = false;
			this->targetGroup->Text = L"Target";
			// 
			// qualityRadio
			// 
			this->qualityRadio->AutoSize = true;
			this->qualityRadio->Checked = true;
			this->qualityRadio->Location = System::Drawing::Point(6, 42);
			this->qualityRadio->Name = L"qualityRadio";
			this->qualityRadio->Size = System::Drawing::Size(57, 17);
			this->qualityRadio->TabIndex = 1;
			this->qualityRadio->TabStop = true;
			this->qualityRadio->Text = L"Quality";
			this->qualityRadio->UseVisualStyleBackColor = true;
			// 
			// bitrateRadio
			// 
			this->bitrateRadio->AutoSize = true;
			this->bitrateRadio->Location = System::Drawing::Point(6, 19);
			this->bitrateRadio->Name = L"bitrateRadio";
			this->bitrateRadio->Size = System::Drawing::Size(55, 17);
			this->bitrateRadio->TabIndex = 0;
			this->bitrateRadio->Text = L"Bitrate";
			this->bitrateRadio->UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->mono);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel1->Location = System::Drawing::Point(359, 3);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(166, 98);
			this->panel1->TabIndex = 1;
			// 
			// mono
			// 
			this->mono->AutoSize = true;
			this->mono->Location = System::Drawing::Point(3, 3);
			this->mono->Name = L"mono";
			this->mono->Size = System::Drawing::Size(100, 17);
			this->mono->TabIndex = 0;
			this->mono->Text = L"Mono encoding";
			this->mono->UseVisualStyleBackColor = true;
			// 
			// bitrateGroup
			// 
			this->tableLayoutPanel2->SetColumnSpan(this->bitrateGroup, 3);
			this->bitrateGroup->Controls->Add(this->lame256);
			this->bitrateGroup->Controls->Add(this->lame128);
			this->bitrateGroup->Controls->Add(this->lame64);
			this->bitrateGroup->Controls->Add(this->lame320);
			this->bitrateGroup->Controls->Add(this->lame8);
			this->bitrateGroup->Controls->Add(this->lame192);
			this->bitrateGroup->Controls->Add(this->cbr);
			this->bitrateGroup->Controls->Add(this->bitrateBar);
			this->bitrateGroup->Dock = System::Windows::Forms::DockStyle::Fill;
			this->bitrateGroup->Location = System::Drawing::Point(3, 107);
			this->bitrateGroup->Name = L"bitrateGroup";
			this->bitrateGroup->Size = System::Drawing::Size(522, 134);
			this->bitrateGroup->TabIndex = 2;
			this->bitrateGroup->TabStop = false;
			this->bitrateGroup->Text = L"Bitrate";
			// 
			// cbr
			// 
			this->cbr->AutoSize = true;
			this->cbr->Location = System::Drawing::Point(55, 90);
			this->cbr->Name = L"cbr";
			this->cbr->Size = System::Drawing::Size(192, 17);
			this->cbr->TabIndex = 1;
			this->cbr->Text = L"Restrict encoder to constant bitrate";
			this->cbr->UseVisualStyleBackColor = true;
			// 
			// bitrateBar
			// 
			this->bitrateBar->LargeChange = 60;
			this->bitrateBar->Location = System::Drawing::Point(6, 39);
			this->bitrateBar->Maximum = 320;
			this->bitrateBar->Minimum = 8;
			this->bitrateBar->Name = L"bitrateBar";
			this->bitrateBar->Size = System::Drawing::Size(510, 45);
			this->bitrateBar->SmallChange = 5;
			this->bitrateBar->TabIndex = 0;
			this->bitrateBar->TickFrequency = 12;
			this->bitrateBar->TickStyle = System::Windows::Forms::TickStyle::TopLeft;
			this->bitrateBar->Value = 192;
			// 
			// qualityGroup
			// 
			this->tableLayoutPanel2->SetColumnSpan(this->qualityGroup, 3);
			this->qualityGroup->Controls->Add(this->lame50);
			this->qualityGroup->Controls->Add(this->lame100);
			this->qualityGroup->Controls->Add(this->lame10);
			this->qualityGroup->Controls->Add(this->label1);
			this->qualityGroup->Controls->Add(this->vbrMode);
			this->qualityGroup->Controls->Add(this->qualBar);
			this->qualityGroup->Dock = System::Windows::Forms::DockStyle::Fill;
			this->qualityGroup->Location = System::Drawing::Point(3, 247);
			this->qualityGroup->Name = L"qualityGroup";
			this->qualityGroup->Size = System::Drawing::Size(522, 118);
			this->qualityGroup->TabIndex = 3;
			this->qualityGroup->TabStop = false;
			this->qualityGroup->Text = L"Quality";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(52, 94);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(106, 13);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Variable bitrate mode";
			// 
			// vbrMode
			// 
			this->vbrMode->FormattingEnabled = true;
			this->vbrMode->Items->AddRange(gcnew cli::array< System::Object^  >(2) {L"standard", L"fast"});
			this->vbrMode->Location = System::Drawing::Point(164, 91);
			this->vbrMode->Name = L"vbrMode";
			this->vbrMode->Size = System::Drawing::Size(140, 21);
			this->vbrMode->TabIndex = 1;
			// 
			// qualBar
			// 
			this->qualBar->Location = System::Drawing::Point(99, 40);
			this->qualBar->Maximum = 100;
			this->qualBar->Minimum = 10;
			this->qualBar->Name = L"qualBar";
			this->qualBar->Size = System::Drawing::Size(317, 45);
			this->qualBar->TabIndex = 0;
			this->qualBar->TickFrequency = 10;
			this->qualBar->TickStyle = System::Windows::Forms::TickStyle::TopLeft;
			this->qualBar->Value = 70;
			// 
			// okButton
			// 
			this->okButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->okButton->Location = System::Drawing::Point(374, 431);
			this->okButton->Name = L"okButton";
			this->okButton->Size = System::Drawing::Size(75, 23);
			this->okButton->TabIndex = 0;
			this->okButton->Text = L"OK";
			this->okButton->UseVisualStyleBackColor = true;
			this->okButton->Click += gcnew System::EventHandler(this, &EncoderOptions::okButton_Click);
			// 
			// cancelButton
			// 
			this->cancelButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->cancelButton->DialogResult = System::Windows::Forms::DialogResult::Cancel;
			this->cancelButton->Location = System::Drawing::Point(455, 431);
			this->cancelButton->Name = L"cancelButton";
			this->cancelButton->Size = System::Drawing::Size(75, 23);
			this->cancelButton->TabIndex = 1;
			this->cancelButton->Text = L"Cancel";
			this->cancelButton->UseVisualStyleBackColor = true;
			// 
			// lamelabel
			// 
			this->lamelabel->AutoSize = true;
			this->lamelabel->Location = System::Drawing::Point(3, 3);
			this->lamelabel->Name = L"lamelabel";
			this->lamelabel->Size = System::Drawing::Size(148, 13);
			this->lamelabel->TabIndex = 4;
			this->lamelabel->Text = L"Using LAME encoding engine";
			// 
			// panel3
			// 
			this->panel3->Controls->Add(this->lamelabel);
			this->panel3->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel3->Location = System::Drawing::Point(3, 371);
			this->panel3->Name = L"panel3";
			this->panel3->Size = System::Drawing::Size(528, 25);
			this->panel3->TabIndex = 1;
			// 
			// lame192
			// 
			this->lame192->AutoSize = true;
			this->lame192->Location = System::Drawing::Point(292, 23);
			this->lame192->Name = L"lame192";
			this->lame192->Size = System::Drawing::Size(25, 13);
			this->lame192->TabIndex = 2;
			this->lame192->Text = L"192";
			// 
			// lame8
			// 
			this->lame8->AutoSize = true;
			this->lame8->Location = System::Drawing::Point(12, 23);
			this->lame8->Name = L"lame8";
			this->lame8->Size = System::Drawing::Size(13, 13);
			this->lame8->TabIndex = 3;
			this->lame8->Text = L"8";
			// 
			// lame320
			// 
			this->lame320->AutoSize = true;
			this->lame320->Location = System::Drawing::Point(491, 23);
			this->lame320->Name = L"lame320";
			this->lame320->Size = System::Drawing::Size(25, 13);
			this->lame320->TabIndex = 4;
			this->lame320->Text = L"320";
			// 
			// lame64
			// 
			this->lame64->AutoSize = true;
			this->lame64->Location = System::Drawing::Point(96, 23);
			this->lame64->Name = L"lame64";
			this->lame64->Size = System::Drawing::Size(19, 13);
			this->lame64->TabIndex = 5;
			this->lame64->Text = L"64";
			// 
			// lame128
			// 
			this->lame128->AutoSize = true;
			this->lame128->Location = System::Drawing::Point(193, 23);
			this->lame128->Name = L"lame128";
			this->lame128->Size = System::Drawing::Size(25, 13);
			this->lame128->TabIndex = 6;
			this->lame128->Text = L"128";
			// 
			// lame256
			// 
			this->lame256->AutoSize = true;
			this->lame256->Location = System::Drawing::Point(391, 23);
			this->lame256->Name = L"lame256";
			this->lame256->Size = System::Drawing::Size(25, 13);
			this->lame256->TabIndex = 7;
			this->lame256->Text = L"256";
			// 
			// lame10
			// 
			this->lame10->AutoSize = true;
			this->lame10->Location = System::Drawing::Point(103, 24);
			this->lame10->Name = L"lame10";
			this->lame10->Size = System::Drawing::Size(19, 13);
			this->lame10->TabIndex = 3;
			this->lame10->Text = L"10";
			// 
			// lame100
			// 
			this->lame100->AutoSize = true;
			this->lame100->Location = System::Drawing::Point(391, 24);
			this->lame100->Name = L"lame100";
			this->lame100->Size = System::Drawing::Size(25, 13);
			this->lame100->TabIndex = 4;
			this->lame100->Text = L"100";
			// 
			// lame50
			// 
			this->lame50->AutoSize = true;
			this->lame50->Location = System::Drawing::Point(232, 24);
			this->lame50->Name = L"lame50";
			this->lame50->Size = System::Drawing::Size(19, 13);
			this->lame50->TabIndex = 5;
			this->lame50->Text = L"50";
			// 
			// EncoderOptions
			// 
			this->AcceptButton = this->okButton;
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->CancelButton = this->cancelButton;
			this->ClientSize = System::Drawing::Size(542, 466);
			this->Controls->Add(this->cancelButton);
			this->Controls->Add(this->tabControl1);
			this->Controls->Add(this->okButton);
			this->Name = L"EncoderOptions";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
			this->Text = L"Encoder Configuration";
			this->tabControl1->ResumeLayout(false);
			this->oggtab->ResumeLayout(false);
			this->lametab->ResumeLayout(false);
			this->tableLayoutPanel2->ResumeLayout(false);
			this->targetGroup->ResumeLayout(false);
			this->targetGroup->PerformLayout();
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->bitrateGroup->ResumeLayout(false);
			this->bitrateGroup->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->bitrateBar))->EndInit();
			this->qualityGroup->ResumeLayout(false);
			this->qualityGroup->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->qualBar))->EndInit();
			this->panel3->ResumeLayout(false);
			this->panel3->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void okButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }
};
}
