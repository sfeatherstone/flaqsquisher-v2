// FlacSquisher - A utility to convert a directory of Flac audio files
// to MP3 or Ogg Vorbis format, preserving the directory structure of
// the Flac files

/*
 Copyright 2008 Michael Brown

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
 
 	http://www.apache.org/licenses/LICENSE-2.0
 
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
*/

#include <io.h>
#include <windows.h>
#include "AboutWindow.h"
#include "OptionsWindow.h"

#pragma once


namespace FlacSquisher {

	using namespace System;
	using namespace System::IO;
	using namespace System::Text;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Diagnostics;
	using namespace System::Collections;
	using namespace System::Threading;

	

	/// <summary>
	/// Summary for FlacToPortable
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class FlacToPortable : public System::Windows::Forms::Form
	{
    public: delegate void ProgressBarUpdateDelegate();

	public:
		FlacToPortable(void)
		{
			Control::CheckForIllegalCrossThreadCalls = false;


			InitializeComponent();

			// set the default (and maximum) number of threads to the
			// number of logical cores in the CPU
			// code from http://msdn.microsoft.com/en-us/library/ms724423(VS.85).aspx
			SYSTEM_INFO siSysInfo;
			GetSystemInfo(&siSysInfo); 
			threadCounter->Value = (int) siSysInfo.dwNumberOfProcessors;
			threadCounter->Maximum = threadCounter->Value;
			
			// add encoder types to the drop-down box
			encoder->Items->Add("OggEnc2 (Ogg Vorbis)");
			encoder->Items->Add("Lame (mp3)");

			findFlac->Visible = false;
			
			settingsPath = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\config.cfg";

			// check if config file exists
			if(File::Exists(settingsPath)){
				loadSettingsFile(settingsPath);
			}
			else{ // load defaults (in executable's directory) if config file does not exist
				oggPath = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\oggenc.exe";
				flacexe = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\flac.exe";
				lamePath = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\lame.exe";
				hidewin = true;
			}

			encodeStatus->Text = "Ready";
			encodeProgress->Size.Width = 0;
			encodeProgress->Visible = false;

			//ProgressBarUpdate = gcnew ProgressBarUpdateDelegate(this, &FlacToPortable::updateProgressBar);

			rwl = gcnew ReaderWriterLock();
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~FlacToPortable()
		{
			if (components)
			{
				delete components;
			}
		}
	

	private: static String^ oggPath;
			 static String^ lamePath;
			 static String^ flacexe;
			 static String^ settingsPath;
			 static String^ flacPath;
			 static String^ outputPath;
			 static String^ options;
			 static int encoderChoice;
			 static System::Collections::Generic::Queue<FileInfo^> jobQueue;
			 static int threadCount;
			 static ReaderWriterLock^ rwl;
			 System::Collections::Generic::List<Thread^> threadList;
			 int initSize; // size of job queue
			 //ProgressBarUpdateDelegate^ ProgressBarUpdate;
			 static bool hidewin;

	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	protected: 
	private: System::Windows::Forms::ToolStripMenuItem^  fileToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  exitToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  helpToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  onlineHelpToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  checkForUpdatesToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  aboutToolStripMenuItem;
	private: System::Windows::Forms::Label^  flacDirLabel;
	private: System::Windows::Forms::TextBox^  flacDir;

	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::TextBox^  outputDir;
	private: System::Windows::Forms::Button^  flacDirButton;
	private: System::Windows::Forms::Button^  outputDirButton;
	private: System::Windows::Forms::ComboBox^  encoder;

	private: System::Windows::Forms::Label^  encoderLabel;


	private: System::Windows::Forms::Label^  cliLabel;
	private: System::Windows::Forms::TextBox^  cliParams;
	private: System::Windows::Forms::GroupBox^  groupBox1;
	private: System::Windows::Forms::GroupBox^  groupBox2;
	private: System::Windows::Forms::ToolStripMenuItem^  toolsToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  optionsToolStripMenuItem;
	private: System::Windows::Forms::Button^  findEncoder;
	private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel1;
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::Button^  encodeButton;
	private: System::Windows::Forms::Button^  exitButton;
	private: System::Windows::Forms::NumericUpDown^  threadCounter;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::Label^  threadsLabel;
	private: System::Windows::Forms::Button^  findFlac;
	private: System::Windows::Forms::StatusStrip^  statusStrip;

	private: System::Windows::Forms::ToolStripProgressBar^  encodeProgress;


	private: System::Windows::Forms::ToolStripStatusLabel^  encodeStatus;





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
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->fileToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->exitToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolsToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->optionsToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->helpToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->onlineHelpToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->checkForUpdatesToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->aboutToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->flacDirLabel = (gcnew System::Windows::Forms::Label());
			this->flacDir = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->outputDir = (gcnew System::Windows::Forms::TextBox());
			this->flacDirButton = (gcnew System::Windows::Forms::Button());
			this->outputDirButton = (gcnew System::Windows::Forms::Button());
			this->encoder = (gcnew System::Windows::Forms::ComboBox());
			this->encoderLabel = (gcnew System::Windows::Forms::Label());
			this->cliParams = (gcnew System::Windows::Forms::TextBox());
			this->cliLabel = (gcnew System::Windows::Forms::Label());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->findFlac = (gcnew System::Windows::Forms::Button());
			this->findEncoder = (gcnew System::Windows::Forms::Button());
			this->tableLayoutPanel1 = (gcnew System::Windows::Forms::TableLayoutPanel());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->exitButton = (gcnew System::Windows::Forms::Button());
			this->encodeButton = (gcnew System::Windows::Forms::Button());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->threadsLabel = (gcnew System::Windows::Forms::Label());
			this->threadCounter = (gcnew System::Windows::Forms::NumericUpDown());
			this->statusStrip = (gcnew System::Windows::Forms::StatusStrip());
			this->encodeProgress = (gcnew System::Windows::Forms::ToolStripProgressBar());
			this->encodeStatus = (gcnew System::Windows::Forms::ToolStripStatusLabel());
			this->menuStrip1->SuspendLayout();
			this->groupBox1->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->tableLayoutPanel1->SuspendLayout();
			this->panel1->SuspendLayout();
			this->panel2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->threadCounter))->BeginInit();
			this->statusStrip->SuspendLayout();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3) {this->fileToolStripMenuItem, 
				this->toolsToolStripMenuItem, this->helpToolStripMenuItem});
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(553, 24);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this->fileToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->exitToolStripMenuItem});
			this->fileToolStripMenuItem->Name = L"fileToolStripMenuItem";
			this->fileToolStripMenuItem->Size = System::Drawing::Size(35, 20);
			this->fileToolStripMenuItem->Text = L"File";
			// 
			// exitToolStripMenuItem
			// 
			this->exitToolStripMenuItem->Name = L"exitToolStripMenuItem";
			this->exitToolStripMenuItem->Size = System::Drawing::Size(92, 22);
			this->exitToolStripMenuItem->Text = L"Exit";
			this->exitToolStripMenuItem->Click += gcnew System::EventHandler(this, &FlacToPortable::exitToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this->toolsToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->optionsToolStripMenuItem});
			this->toolsToolStripMenuItem->Name = L"toolsToolStripMenuItem";
			this->toolsToolStripMenuItem->Size = System::Drawing::Size(44, 20);
			this->toolsToolStripMenuItem->Text = L"Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this->optionsToolStripMenuItem->Name = L"optionsToolStripMenuItem";
			this->optionsToolStripMenuItem->Size = System::Drawing::Size(123, 22);
			this->optionsToolStripMenuItem->Text = L"Options...";
			this->optionsToolStripMenuItem->Click += gcnew System::EventHandler(this, &FlacToPortable::optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this->helpToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(3) {this->onlineHelpToolStripMenuItem, 
				this->checkForUpdatesToolStripMenuItem, this->aboutToolStripMenuItem});
			this->helpToolStripMenuItem->Name = L"helpToolStripMenuItem";
			this->helpToolStripMenuItem->Size = System::Drawing::Size(40, 20);
			this->helpToolStripMenuItem->Text = L"Help";
			// 
			// onlineHelpToolStripMenuItem
			// 
			this->onlineHelpToolStripMenuItem->Name = L"onlineHelpToolStripMenuItem";
			this->onlineHelpToolStripMenuItem->Size = System::Drawing::Size(163, 22);
			this->onlineHelpToolStripMenuItem->Text = L"Online Help";
			this->onlineHelpToolStripMenuItem->Click += gcnew System::EventHandler(this, &FlacToPortable::onlineHelpToolStripMenuItem_Click);
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this->checkForUpdatesToolStripMenuItem->Name = L"checkForUpdatesToolStripMenuItem";
			this->checkForUpdatesToolStripMenuItem->Size = System::Drawing::Size(163, 22);
			this->checkForUpdatesToolStripMenuItem->Text = L"Check for Updates";
			this->checkForUpdatesToolStripMenuItem->Click += gcnew System::EventHandler(this, &FlacToPortable::checkForUpdatesToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this->aboutToolStripMenuItem->Name = L"aboutToolStripMenuItem";
			this->aboutToolStripMenuItem->Size = System::Drawing::Size(163, 22);
			this->aboutToolStripMenuItem->Text = L"About...";
			this->aboutToolStripMenuItem->Click += gcnew System::EventHandler(this, &FlacToPortable::aboutToolStripMenuItem_Click);
			// 
			// flacDirLabel
			// 
			this->flacDirLabel->AutoSize = true;
			this->flacDirLabel->Location = System::Drawing::Point(3, 16);
			this->flacDirLabel->Name = L"flacDirLabel";
			this->flacDirLabel->Size = System::Drawing::Size(78, 13);
			this->flacDirLabel->TabIndex = 1;
			this->flacDirLabel->Text = L"FLAC Directory";
			// 
			// flacDir
			// 
			this->flacDir->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->flacDir->Location = System::Drawing::Point(3, 32);
			this->flacDir->Name = L"flacDir";
			this->flacDir->Size = System::Drawing::Size(315, 20);
			this->flacDir->TabIndex = 2;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(3, 55);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(84, 13);
			this->label1->TabIndex = 3;
			this->label1->Text = L"Output Directory";
			// 
			// outputDir
			// 
			this->outputDir->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->outputDir->Location = System::Drawing::Point(3, 71);
			this->outputDir->Name = L"outputDir";
			this->outputDir->Size = System::Drawing::Size(315, 20);
			this->outputDir->TabIndex = 4;
			// 
			// flacDirButton
			// 
			this->flacDirButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->flacDirButton->Location = System::Drawing::Point(324, 32);
			this->flacDirButton->Name = L"flacDirButton";
			this->flacDirButton->Size = System::Drawing::Size(75, 23);
			this->flacDirButton->TabIndex = 5;
			this->flacDirButton->Text = L"Change...";
			this->flacDirButton->UseVisualStyleBackColor = true;
			this->flacDirButton->Click += gcnew System::EventHandler(this, &FlacToPortable::flacDirButton_Click);
			// 
			// outputDirButton
			// 
			this->outputDirButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->outputDirButton->Location = System::Drawing::Point(324, 71);
			this->outputDirButton->Name = L"outputDirButton";
			this->outputDirButton->Size = System::Drawing::Size(75, 23);
			this->outputDirButton->TabIndex = 6;
			this->outputDirButton->Text = L"Change...";
			this->outputDirButton->UseVisualStyleBackColor = true;
			this->outputDirButton->Click += gcnew System::EventHandler(this, &FlacToPortable::outputDirButton_Click);
			// 
			// encoder
			// 
			this->encoder->FormattingEnabled = true;
			this->encoder->Location = System::Drawing::Point(3, 32);
			this->encoder->Name = L"encoder";
			this->encoder->Size = System::Drawing::Size(160, 21);
			this->encoder->TabIndex = 7;
			this->encoder->SelectedIndexChanged += gcnew System::EventHandler(this, &FlacToPortable::encoder_SelectedIndexChanged);
			// 
			// encoderLabel
			// 
			this->encoderLabel->AutoSize = true;
			this->encoderLabel->Location = System::Drawing::Point(3, 16);
			this->encoderLabel->Name = L"encoderLabel";
			this->encoderLabel->Size = System::Drawing::Size(47, 13);
			this->encoderLabel->TabIndex = 8;
			this->encoderLabel->Text = L"Encoder";
			// 
			// cliParams
			// 
			this->cliParams->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->cliParams->Location = System::Drawing::Point(3, 76);
			this->cliParams->Name = L"cliParams";
			this->cliParams->Size = System::Drawing::Size(401, 20);
			this->cliParams->TabIndex = 10;
			// 
			// cliLabel
			// 
			this->cliLabel->AutoSize = true;
			this->cliLabel->Location = System::Drawing::Point(6, 60);
			this->cliLabel->Name = L"cliLabel";
			this->cliLabel->Size = System::Drawing::Size(80, 13);
			this->cliLabel->TabIndex = 9;
			this->cliLabel->Text = L"Command Line:";
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->flacDirLabel);
			this->groupBox1->Controls->Add(this->outputDirButton);
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->Controls->Add(this->flacDir);
			this->groupBox1->Controls->Add(this->flacDirButton);
			this->groupBox1->Controls->Add(this->outputDir);
			this->groupBox1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->groupBox1->Location = System::Drawing::Point(3, 3);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(410, 100);
			this->groupBox1->TabIndex = 11;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Directories";
			// 
			// groupBox2
			// 
			this->groupBox2->Controls->Add(this->findFlac);
			this->groupBox2->Controls->Add(this->findEncoder);
			this->groupBox2->Controls->Add(this->cliParams);
			this->groupBox2->Controls->Add(this->encoderLabel);
			this->groupBox2->Controls->Add(this->cliLabel);
			this->groupBox2->Controls->Add(this->encoder);
			this->groupBox2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->groupBox2->Location = System::Drawing::Point(3, 109);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(410, 104);
			this->groupBox2->TabIndex = 12;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"Encoder Options";
			// 
			// findFlac
			// 
			this->findFlac->Location = System::Drawing::Point(264, 31);
			this->findFlac->Name = L"findFlac";
			this->findFlac->Size = System::Drawing::Size(88, 23);
			this->findFlac->TabIndex = 12;
			this->findFlac->Text = L"Flac Decoder...";
			this->findFlac->UseVisualStyleBackColor = true;
			this->findFlac->Visible = false;
			this->findFlac->Click += gcnew System::EventHandler(this, &FlacToPortable::findFlac_Click);
			// 
			// findEncoder
			// 
			this->findEncoder->Location = System::Drawing::Point(169, 31);
			this->findEncoder->Name = L"findEncoder";
			this->findEncoder->Size = System::Drawing::Size(89, 23);
			this->findEncoder->TabIndex = 11;
			this->findEncoder->Text = L"Find Encoder...";
			this->findEncoder->UseVisualStyleBackColor = true;
			this->findEncoder->Visible = false;
			this->findEncoder->Click += gcnew System::EventHandler(this, &FlacToPortable::findEncoder_Click);
			// 
			// tableLayoutPanel1
			// 
			this->tableLayoutPanel1->ColumnCount = 2;
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
				75.3894F)));
			this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
				24.61059F)));
			this->tableLayoutPanel1->Controls->Add(this->groupBox2, 0, 1);
			this->tableLayoutPanel1->Controls->Add(this->groupBox1, 0, 0);
			this->tableLayoutPanel1->Controls->Add(this->panel1, 1, 1);
			this->tableLayoutPanel1->Controls->Add(this->panel2, 1, 0);
			this->tableLayoutPanel1->Controls->Add(this->statusStrip, 0, 2);
			this->tableLayoutPanel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->tableLayoutPanel1->Location = System::Drawing::Point(0, 24);
			this->tableLayoutPanel1->Name = L"tableLayoutPanel1";
			this->tableLayoutPanel1->RowCount = 3;
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 49.07407F)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 50.92593F)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Absolute, 22)));
			this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Absolute, 20)));
			this->tableLayoutPanel1->Size = System::Drawing::Size(553, 239);
			this->tableLayoutPanel1->TabIndex = 13;
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->exitButton);
			this->panel1->Controls->Add(this->encodeButton);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel1->Location = System::Drawing::Point(419, 109);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(131, 104);
			this->panel1->TabIndex = 13;
			// 
			// exitButton
			// 
			this->exitButton->DialogResult = System::Windows::Forms::DialogResult::Cancel;
			this->exitButton->Location = System::Drawing::Point(3, 32);
			this->exitButton->Name = L"exitButton";
			this->exitButton->Size = System::Drawing::Size(75, 23);
			this->exitButton->TabIndex = 1;
			this->exitButton->Text = L"Exit";
			this->exitButton->UseVisualStyleBackColor = true;
			this->exitButton->Click += gcnew System::EventHandler(this, &FlacToPortable::exitButton_Click);
			// 
			// encodeButton
			// 
			this->encodeButton->Location = System::Drawing::Point(3, 3);
			this->encodeButton->Name = L"encodeButton";
			this->encodeButton->Size = System::Drawing::Size(75, 23);
			this->encodeButton->TabIndex = 0;
			this->encodeButton->Text = L"Encode!";
			this->encodeButton->UseVisualStyleBackColor = true;
			this->encodeButton->Click += gcnew System::EventHandler(this, &FlacToPortable::encodeButton_Click);
			// 
			// panel2
			// 
			this->panel2->Controls->Add(this->threadsLabel);
			this->panel2->Controls->Add(this->threadCounter);
			this->panel2->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel2->Location = System::Drawing::Point(419, 3);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(131, 100);
			this->panel2->TabIndex = 14;
			// 
			// threadsLabel
			// 
			this->threadsLabel->AutoSize = true;
			this->threadsLabel->Location = System::Drawing::Point(4, 4);
			this->threadsLabel->Name = L"threadsLabel";
			this->threadsLabel->Size = System::Drawing::Size(98, 13);
			this->threadsLabel->TabIndex = 15;
			this->threadsLabel->Text = L"Number of Threads";
			// 
			// threadCounter
			// 
			this->threadCounter->Location = System::Drawing::Point(3, 20);
			this->threadCounter->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {8, 0, 0, 0});
			this->threadCounter->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {1, 0, 0, 0});
			this->threadCounter->Name = L"threadCounter";
			this->threadCounter->Size = System::Drawing::Size(37, 20);
			this->threadCounter->TabIndex = 14;
			this->threadCounter->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {1, 0, 0, 0});
			// 
			// statusStrip
			// 
			this->tableLayoutPanel1->SetColumnSpan(this->statusStrip, 2);
			this->statusStrip->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {this->encodeProgress, 
				this->encodeStatus});
			this->statusStrip->Location = System::Drawing::Point(0, 217);
			this->statusStrip->Name = L"statusStrip";
			this->statusStrip->Size = System::Drawing::Size(553, 22);
			this->statusStrip->TabIndex = 15;
			// 
			// encodeProgress
			// 
			this->encodeProgress->MarqueeAnimationSpeed = 10;
			this->encodeProgress->Name = L"encodeProgress";
			this->encodeProgress->Size = System::Drawing::Size(200, 16);
			this->encodeProgress->Visible = false;
			// 
			// encodeStatus
			// 
			this->encodeStatus->Name = L"encodeStatus";
			this->encodeStatus->Size = System::Drawing::Size(38, 17);
			this->encodeStatus->Text = L"Ready";
			// 
			// FlacToPortable
			// 
			this->AcceptButton = this->encodeButton;
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->CancelButton = this->exitButton;
			this->ClientSize = System::Drawing::Size(553, 263);
			this->Controls->Add(this->tableLayoutPanel1);
			this->Controls->Add(this->menuStrip1);
			this->MainMenuStrip = this->menuStrip1;
			this->Name = L"FlacToPortable";
			this->Text = L"FlacSquisher v0.0.2";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &FlacToPortable::FlacToPortable_FormClosing);
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->groupBox2->PerformLayout();
			this->tableLayoutPanel1->ResumeLayout(false);
			this->tableLayoutPanel1->PerformLayout();
			this->panel1->ResumeLayout(false);
			this->panel2->ResumeLayout(false);
			this->panel2->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->threadCounter))->EndInit();
			this->statusStrip->ResumeLayout(false);
			this->statusStrip->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	// called on initialization to restore the settings from the last session (called only if the config file exists)
	private: int loadSettingsFile(String^ filePath){
			 try{
				 StreamReader^ sr = gcnew StreamReader(filePath, Encoding::UTF8);
				 flacDir->Text = sr->ReadLine();
				 outputDir->Text = sr->ReadLine();
				 encoder->SelectedIndex = Convert::ToInt32(sr->ReadLine());
				 oggPath = sr->ReadLine();
				 flacexe = sr->ReadLine();
				 lamePath = sr->ReadLine();
				 cliParams->Text = sr->ReadLine();
				 hidewin = bool::Parse(sr->ReadLine());
				 sr->Close();
				 return 1;
			 }
			 catch(Exception^ ex){ // any settings loaded before the error remain -- this may or may not be desired
				 MessageBox::Show("Could not read correctly from file: " + ex->ToString());
				 return 0;
			 }
		 }
    // called on formClose to save settings from this session
	private: int saveSettingsFile(String^ filePath){
			 try{
				 StreamWriter^ sw = gcnew StreamWriter(filePath, false, Encoding::UTF8); // false is "Don't append"
				 sw->Write(flacDir->Text + Environment::NewLine);
				 sw->Write(outputDir->Text + Environment::NewLine);
				 sw->Write(encoder->SelectedIndex + Environment::NewLine);
				 sw->Write(oggPath + Environment::NewLine);
				 sw->Write(flacexe + Environment::NewLine);
				 sw->Write(lamePath + Environment::NewLine);
				 sw->Write(cliParams->Text + Environment::NewLine);
				 sw->Write(hidewin.ToString());
				 sw->Close();
				 return 1;
			 }
			 catch(Exception^ ex){ // any errors are likely discovered on attempting to open the file, so most likely nothing is written
				 MessageBox::Show("Could not write to file: " + ex->ToString());
				 return 0;
			 }
			 
		 }
	// called by File->Exit menu item
	private: System::Void exitToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }
// called by Exit button on form
private: System::Void exitButton_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->Close();
		 }
// chooses "source" directory containing Flac files to be recoded
private: System::Void flacDirButton_Click(System::Object^  sender, System::EventArgs^  e) {
			 FolderBrowserDialog^ fbd = gcnew FolderBrowserDialog();
			 if(fbd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
			     flacDir->Text = fbd->SelectedPath;
			 }
		 }
// chooses "destination" directory to contain files output by the recoding
private: System::Void outputDirButton_Click(System::Object^  sender, System::EventArgs^  e) {
			 FolderBrowserDialog^ fbd = gcnew FolderBrowserDialog();
			 if(fbd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
			     outputDir->Text = fbd->SelectedPath;
			 }
		 }
// if encoder is changed, load default command-line options for that encoder
private: System::Void encoder_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 if(encoder->SelectedIndex == 0){
			     cliParams->Text = "-q 6"; // oggenc options
			 }
			 else{
			     cliParams->Text = "-V2 --vbr-new -q0"; // lame options
			 }
		 }
// deprecated function -- encoders are now selected in the Tools->Options window
private: System::Void findEncoder_Click(System::Object^  sender, System::EventArgs^  e) {
			 OpenFileDialog^ ofd = gcnew OpenFileDialog();
			 ofd->Filter = "Executable Files (*.exe)|*.exe";
			 if(ofd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
				 if(encoder->SelectedIndex == 0){
				     oggPath = ofd->FileName;
				 }
				 else{
				     lamePath = ofd->FileName;
				 }
			 }
		 }
// deprecated function -- encoders are now selected in the Tools->Options window
private: System::Void findFlac_Click(System::Object^  sender, System::EventArgs^  e) {
			 OpenFileDialog^ ofd = gcnew OpenFileDialog();
			 ofd->Filter = "Executable Files (*.exe)|*.exe";
			 if(ofd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
				 flacexe = ofd->FileName;
			 }
		 }
// called with "Encode" button -- queues files in the "source" directory to be processed,
// then starts 'n' encoding threads to process the queue
private: System::Void encodeButton_Click(System::Object^  sender, System::EventArgs^  e) {
			 // disable encodeButton until encoding is finished
			 encodeButton->Enabled = false;
			 // this section should be kept in case of bad config files, etc.
			 if(encoder->SelectedIndex == 0){
				 if (String::IsNullOrEmpty(oggPath))
			     {
					 oggPath = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\oggenc.exe";
			     }
			 }
			 else{
				 if(String::IsNullOrEmpty(lamePath)){
					 lamePath = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\lame.exe";
				 }
				 if(String::IsNullOrEmpty(flacexe)){
					 flacexe = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\flac.exe";
				 }
			 }

			 // set up status bar
			 encodeStatus->Text = "Recursing directories...";
			 encodeProgress->Width = 200;
			 encodeProgress->Value = 0;
			 encodeProgress->MarqueeAnimationSpeed = 35;
			 encodeProgress->Style = ProgressBarStyle::Marquee;
			 encodeProgress->Visible = true;

			 // find files in "source" directory
			 recurseDirs(flacDir->Text);

			 // set up encoder
			 flacPath = flacDir->Text;
			 outputPath = outputDir->Text;
			 encoderChoice = encoder->SelectedIndex;
			 options = cliParams->Text;

			 encodeStatus->Text = "Setting up threads...";
			 rwl->AcquireWriterLock(-1); // -1 == wait forever for the lock
			 try{
				 threadCount = (int) threadCounter->Value; // Value is a System::Decimal, hence the cast
			 }
			 finally{
				 rwl->ReleaseWriterLock();
			 }

			 // update status bar
			 encodeStatus->Text = "Starting to encode...";
			 encodeProgress->Style = ProgressBarStyle::Continuous;
			 encodeProgress->Value = 0;
			 encodeProgress->Maximum = jobQueue.Count;

			 // set up 'n' threads for processing the queue
			 for(int i=0; i<threadCounter->Value; i++){
				 Thread^ InstanceCaller = gcnew Thread(
		         gcnew ThreadStart(this, &FlacToPortable::encodingThread));
				 InstanceCaller->IsBackground = true;
				 threadList.Add(InstanceCaller);

			     // Start the thread.
			     InstanceCaller->Start();
				 
			 }
			 encodeStatus->Text = encodeProgress->Value + " of " + encodeProgress->Maximum + " files completed";
		 }

private: void updateProgressBar(){
			 // bounds checking
			 encodeProgress->Value = min((encodeProgress->Value + 1), encodeProgress->Maximum);
			 // update the status text
		     encodeStatus->Text = encodeProgress->Value + " of " + encodeProgress->Maximum + " files completed";
			 // refresh the window, just in case
			 this->Refresh();
		 }
private: void encodingThread(){
			 try{ // exception will occur when queue is empty
			     FileInfo^ fi;
				 // goes until the queue is empty
			     while(fi = jobQueue.Dequeue()){
				     encodeFile(fi);

					 // increment "value" on the progress bar by one
					 updateProgressBar();
			     }
			 }
			 finally{
				 // enable the encode button only if this is the last thread executing
				 rwl->AcquireWriterLock(-1);
                 try{
                     if(threadCount > 1){
						 try{
							 threadCount--;
						 }
						 finally{
						 }
                     }
                     else{
						 encodeButton->Enabled = true;
                     }
				 }
				 finally{
					 rwl->ReleaseWriterLock();
				 }
			 }
		 }
// recurse through the directories and add all files found to the queue
private: void recurseDirs(String^ rootDir) {
					  DirectoryInfo^ dirinfo = gcnew DirectoryInfo(rootDir);
					  
					  for each(FileInfo^ fi in dirinfo->GetFiles()){
						  jobQueue.Enqueue(fi);
					  }
					  // pseudo-tail-recursive, if this compiler is helped by that at all
					  for each(DirectoryInfo^ di in dirinfo->GetDirectories()){
						  recurseDirs(di->FullName);
					  }
				  }
// take the file file passed in, and encode it using the selected encoder and options
private: void encodeFile(FileInfo^ fi){
					  // get the portion of the path that will be shared by the source and destination paths
				      String^ partialPath = fi->DirectoryName->Remove(0, flacPath->Length);
					  String^ destPath;
					  if(encoderChoice == 0){
						  destPath = outputPath + partialPath + "\\" + fi->Name->Replace(".flac", ".ogg");
					  }
					  else{
						  destPath = outputPath + partialPath + "\\" + fi->Name->Replace(".flac", ".mp3");
					  }
					  // if the resulting path exists already, we don't need to encode again
					  if(File::Exists(destPath)){
					      return;
					  }
					  // LAME doesn't like to output to non-existent directories
					  if(!Directory::Exists(outputPath + partialPath)){
						  Directory::CreateDirectory(outputPath + partialPath);
					  }

					  // this code was an early attempt to keep one thread within one cmd window
					  /*Process^ p = gcnew Process();
					  p->StartInfo->FileName = "cmd.exe";
					  p->StartInfo->UseShellExecute = false;
					  p->StartInfo->CreateNoWindow = true;
					  //string args = "\"" + lameFile.Text + "\"" + " " + options + " \"" + inputFile.Text + "\"";

					  p->StartInfo->WindowStyle = System::Diagnostics::ProcessWindowStyle::Normal;
					  p->StartInfo->RedirectStandardInput = true;
					  //p.StartInfo.RedirectStandardError = true;
					  //p.StartInfo.RedirectStandardOutput = true;
					  p->Start();

					  StreamWriter^ sIn = p->StandardInput;
					  sIn->AutoFlush = true;

					  //StreamReader sOut = p.StandardOutput;
					  //StreamReader sErr = p.StandardError;

					  MessageBox::Show("\"" + oggPath + "\"" + " " + "\"" + fi->FullName + "\" \"" + destPath + "\" " + cliParams->Text);

					  if(encoder->SelectedIndex == 0){
					      sIn->Write("\"" + oggPath + "\"");
					  }
					  else{
					      sIn->Write("\"" + lamePath + "\"");
					  }
					  sIn->WriteLine(" " + "\"" + fi->FullName + "\" \"" + destPath + "\" " + cliParams->Text);
					  //sIn->WriteLine("exit");

					  //String s = sErr.ReadToEnd();
					  p->WaitForExit(10000);

					  //status.Text += "Process output:" + Environment.NewLine + s;
					  //status.Update();

					  //sOut.Close();
					  //sErr.Close();
					  sIn->Close();
					  p->Close();
					  */

					  // call different things on the command line, depending on which encoder is being used
					  ProcessStartInfo^ psi = gcnew ProcessStartInfo();
					  if(encoderChoice == 0){
						  // oggenc can take Flac files as input, so no decoding necessary
					      psi->FileName = oggPath;
						  psi->Arguments = "\"" + fi->FullName + "\" -o \"" + destPath + "\" " + options;
					  }
					  else{
						  // LAME cannot take Flac files as input as of 3.97, so we need to decode using flac.exe first
					      psi->FileName = "cmd.exe";
						  // "/s" switch allows us to give the arguments of "/c" inside quotes
						  psi->Arguments = "/s /c \"\"" + flacexe + "\" -dc \"" + fi->FullName + "\" | \"" + lamePath + "\" " + options + " --verbose - \"" + destPath + "\"\"";
					  }
					  
					  //status.Text += "Calling Lame with arguments: " + psi.Arguments
						  //+ Environment.NewLine;
					  //status.Update();

					  if(hidewin){
						  psi->WindowStyle = ProcessWindowStyle::Hidden;
					  }
					  else{
						  psi->WindowStyle = ProcessWindowStyle::Normal;
					  }
					  System::Diagnostics::Process^ p = System::Diagnostics::Process::Start(psi);

					  // don't set a timeout, cause encoding could take a long time, depending on CPU speed, load, and file length
					  p->WaitForExit();

					  // close the process handle when it's exited
					  p->Close();
				  }
// when the program is being closed, save the config file
private: System::Void FlacToPortable_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
		     saveSettingsFile(settingsPath);
		 }
// goes to the project page. Maybe send them instead to the forums?
private: System::Void onlineHelpToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
			 WebBrowser^ wb = gcnew WebBrowser();
			 // second argument of Navigate() puts URL in new window rather than an internal form
			 wb->Navigate("https://sourceforge.net/projects/flacsquisher/", true);
		 }
// open the options window
private: System::Void optionsToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
			 OptionsWindow^ ow = gcnew OptionsWindow();
			 // populate the window with the current encoder path values
			 ow->setOgg(oggPath);
			 ow->setLame(lamePath);
			 ow->setFlac(flacexe);
			 ow->setHide(hidewin);
			 ow->ShowDialog(this);

			 if(ow->DialogResult == Windows::Forms::DialogResult::OK){
				 // write the values back
			     oggPath = ow->getOgg();
			     lamePath = ow->getLame();
				 flacexe = ow->getFlac();
				 hidewin = ow->getHide();
			 }
		 }
// eventually, this method will check with a server to see if there's a newer version
// for now, open up the project page so the user can check for updates
private: System::Void checkForUpdatesToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
			 WebBrowser^ wb = gcnew WebBrowser();
			 // second argument of Navigate() puts URL in new window rather than an internal form
			 wb->Navigate("https://sourceforge.net/projects/flacsquisher/", true);
		 }
// bring up the About window
private: System::Void aboutToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
			 AboutWindow^ aw = gcnew AboutWindow();
			 aw->ShowDialog(this);
		 }
};
}
