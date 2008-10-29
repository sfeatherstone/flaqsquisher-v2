#pragma once

#include "EncoderOptions.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace FlacSquisher {

    /// <summary>
    /// Summary for OptionsWindow
    ///
    /// WARNING: If you change the name of this class, you will need to change the
    ///          'Resource File Name' property for the managed resource compiler tool
    ///          associated with all .resx files this class depends on.  Otherwise,
    ///          the designers will not be able to interact properly with localized
    ///          resources associated with this form.
    /// </summary>
    public ref class OptionsWindow : public System::Windows::Forms::Form
    {
    public:
        OptionsWindow(void)
        {
            InitializeComponent();
            //
            //TODO: Add the constructor code here
            //
			encoderStr = "";
			encoderChoice = -1;
        }

    protected:
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        ~OptionsWindow()
        {
            if (components)
            {
                delete components;
            }
        }
	private: String^ encoderStr;
			 int encoderChoice;

    private: System::Windows::Forms::Label^  OggencLabel;
    private: System::Windows::Forms::TextBox^  oggLocation;
    protected: 

    private: System::Windows::Forms::Button^  oggButton;

    private: System::Windows::Forms::Label^  FlacLabel;
    private: System::Windows::Forms::TextBox^  flacLocation;

    private: System::Windows::Forms::Button^  flacButton;

    private: System::Windows::Forms::Label^  LameLabel;
    private: System::Windows::Forms::TextBox^  lameLocation;

    private: System::Windows::Forms::Button^  lameButton;
    private: System::Windows::Forms::Button^  cancelButton;
    private: System::Windows::Forms::Button^  okButton;
    private: System::Windows::Forms::Button^  resetButton;
    private: System::Windows::Forms::CheckBox^  hideCmd;

    private: System::Windows::Forms::TableLayoutPanel^  tableLayoutPanel1;
    private: System::Windows::Forms::GroupBox^  encoderBox;

    private: System::Windows::Forms::Panel^  panel1;
    private: System::Windows::Forms::Panel^  panel2;
    private: System::Windows::Forms::Button^  encOptsButton;




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
            this->OggencLabel = (gcnew System::Windows::Forms::Label());
            this->oggLocation = (gcnew System::Windows::Forms::TextBox());
            this->oggButton = (gcnew System::Windows::Forms::Button());
            this->FlacLabel = (gcnew System::Windows::Forms::Label());
            this->flacLocation = (gcnew System::Windows::Forms::TextBox());
            this->flacButton = (gcnew System::Windows::Forms::Button());
            this->LameLabel = (gcnew System::Windows::Forms::Label());
            this->lameLocation = (gcnew System::Windows::Forms::TextBox());
            this->lameButton = (gcnew System::Windows::Forms::Button());
            this->cancelButton = (gcnew System::Windows::Forms::Button());
            this->okButton = (gcnew System::Windows::Forms::Button());
            this->resetButton = (gcnew System::Windows::Forms::Button());
            this->hideCmd = (gcnew System::Windows::Forms::CheckBox());
            this->tableLayoutPanel1 = (gcnew System::Windows::Forms::TableLayoutPanel());
            this->encoderBox = (gcnew System::Windows::Forms::GroupBox());
            this->panel1 = (gcnew System::Windows::Forms::Panel());
            this->panel2 = (gcnew System::Windows::Forms::Panel());
            this->encOptsButton = (gcnew System::Windows::Forms::Button());
            this->tableLayoutPanel1->SuspendLayout();
            this->encoderBox->SuspendLayout();
            this->panel1->SuspendLayout();
            this->panel2->SuspendLayout();
            this->SuspendLayout();
            // 
            // OggencLabel
            // 
            this->OggencLabel->AutoSize = true;
            this->OggencLabel->Location = System::Drawing::Point(7, 16);
            this->OggencLabel->Name = L"OggencLabel";
            this->OggencLabel->Size = System::Drawing::Size(70, 13);
            this->OggencLabel->TabIndex = 0;
            this->OggencLabel->Text = L"Ogg Encoder";
            // 
            // oggLocation
            // 
            this->oggLocation->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right));
            this->oggLocation->Location = System::Drawing::Point(7, 32);
            this->oggLocation->Name = L"oggLocation";
            this->oggLocation->Size = System::Drawing::Size(332, 20);
            this->oggLocation->TabIndex = 1;
            // 
            // oggButton
            // 
            this->oggButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
            this->oggButton->Location = System::Drawing::Point(345, 30);
            this->oggButton->Name = L"oggButton";
            this->oggButton->Size = System::Drawing::Size(75, 23);
            this->oggButton->TabIndex = 2;
            this->oggButton->Text = L"Choose...";
            this->oggButton->UseVisualStyleBackColor = true;
            this->oggButton->Click += gcnew System::EventHandler(this, &OptionsWindow::oggButton_Click);
            // 
            // FlacLabel
            // 
            this->FlacLabel->AutoSize = true;
            this->FlacLabel->Location = System::Drawing::Point(7, 55);
            this->FlacLabel->Name = L"FlacLabel";
            this->FlacLabel->Size = System::Drawing::Size(71, 13);
            this->FlacLabel->TabIndex = 3;
            this->FlacLabel->Text = L"Flac Decoder";
            // 
            // flacLocation
            // 
            this->flacLocation->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right));
            this->flacLocation->Location = System::Drawing::Point(7, 71);
            this->flacLocation->Name = L"flacLocation";
            this->flacLocation->Size = System::Drawing::Size(332, 20);
            this->flacLocation->TabIndex = 4;
            // 
            // flacButton
            // 
            this->flacButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
            this->flacButton->Location = System::Drawing::Point(345, 69);
            this->flacButton->Name = L"flacButton";
            this->flacButton->Size = System::Drawing::Size(75, 23);
            this->flacButton->TabIndex = 5;
            this->flacButton->Text = L"Choose...";
            this->flacButton->UseVisualStyleBackColor = true;
            this->flacButton->Click += gcnew System::EventHandler(this, &OptionsWindow::flacButton_Click);
            // 
            // LameLabel
            // 
            this->LameLabel->AutoSize = true;
            this->LameLabel->Location = System::Drawing::Point(7, 94);
            this->LameLabel->Name = L"LameLabel";
            this->LameLabel->Size = System::Drawing::Size(76, 13);
            this->LameLabel->TabIndex = 6;
            this->LameLabel->Text = L"Lame Encoder";
            // 
            // lameLocation
            // 
            this->lameLocation->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right));
            this->lameLocation->Location = System::Drawing::Point(7, 110);
            this->lameLocation->Name = L"lameLocation";
            this->lameLocation->Size = System::Drawing::Size(332, 20);
            this->lameLocation->TabIndex = 7;
            // 
            // lameButton
            // 
            this->lameButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
            this->lameButton->Location = System::Drawing::Point(345, 108);
            this->lameButton->Name = L"lameButton";
            this->lameButton->Size = System::Drawing::Size(75, 23);
            this->lameButton->TabIndex = 8;
            this->lameButton->Text = L"Choose...";
            this->lameButton->UseVisualStyleBackColor = true;
            this->lameButton->Click += gcnew System::EventHandler(this, &OptionsWindow::lameButton_Click);
            // 
            // cancelButton
            // 
            this->cancelButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
            this->cancelButton->DialogResult = System::Windows::Forms::DialogResult::Cancel;
            this->cancelButton->Location = System::Drawing::Point(125, 3);
            this->cancelButton->Name = L"cancelButton";
            this->cancelButton->Size = System::Drawing::Size(75, 23);
            this->cancelButton->TabIndex = 9;
            this->cancelButton->Text = L"Cancel";
            this->cancelButton->UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this->okButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
            this->okButton->DialogResult = System::Windows::Forms::DialogResult::OK;
            this->okButton->Location = System::Drawing::Point(44, 3);
            this->okButton->Name = L"okButton";
            this->okButton->Size = System::Drawing::Size(75, 23);
            this->okButton->TabIndex = 10;
            this->okButton->Text = L"OK";
            this->okButton->UseVisualStyleBackColor = true;
            this->okButton->Click += gcnew System::EventHandler(this, &OptionsWindow::okButton_Click);
            // 
            // resetButton
            // 
            this->resetButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
            this->resetButton->Location = System::Drawing::Point(3, 190);
            this->resetButton->Name = L"resetButton";
            this->resetButton->Size = System::Drawing::Size(75, 23);
            this->resetButton->TabIndex = 11;
            this->resetButton->Text = L"Defaults";
            this->resetButton->UseVisualStyleBackColor = true;
            this->resetButton->Click += gcnew System::EventHandler(this, &OptionsWindow::resetButton_Click);
            // 
            // hideCmd
            // 
            this->hideCmd->AutoSize = true;
            this->hideCmd->Checked = true;
            this->hideCmd->CheckState = System::Windows::Forms::CheckState::Checked;
            this->hideCmd->Location = System::Drawing::Point(3, 150);
            this->hideCmd->Name = L"hideCmd";
            this->hideCmd->Size = System::Drawing::Size(178, 17);
            this->hideCmd->TabIndex = 12;
            this->hideCmd->Text = L"Hide Command Prompt windows";
            this->hideCmd->UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this->tableLayoutPanel1->ColumnCount = 2;
            this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
                51.63551F)));
            this->tableLayoutPanel1->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent, 
                48.36449F)));
            this->tableLayoutPanel1->Controls->Add(this->encoderBox, 0, 0);
            this->tableLayoutPanel1->Controls->Add(this->panel1, 1, 2);
            this->tableLayoutPanel1->Controls->Add(this->resetButton, 0, 2);
            this->tableLayoutPanel1->Controls->Add(this->hideCmd, 0, 1);
            this->tableLayoutPanel1->Controls->Add(this->panel2, 1, 1);
            this->tableLayoutPanel1->Dock = System::Windows::Forms::DockStyle::Fill;
            this->tableLayoutPanel1->Location = System::Drawing::Point(0, 0);
            this->tableLayoutPanel1->Name = L"tableLayoutPanel1";
            this->tableLayoutPanel1->RowCount = 3;
            this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 81.21547F)));
            this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent, 18.78453F)));
            this->tableLayoutPanel1->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Absolute, 34)));
            this->tableLayoutPanel1->Size = System::Drawing::Size(432, 216);
            this->tableLayoutPanel1->TabIndex = 13;
            // 
            // encoderBox
            // 
            this->tableLayoutPanel1->SetColumnSpan(this->encoderBox, 2);
            this->encoderBox->Controls->Add(this->OggencLabel);
            this->encoderBox->Controls->Add(this->oggLocation);
            this->encoderBox->Controls->Add(this->oggButton);
            this->encoderBox->Controls->Add(this->FlacLabel);
            this->encoderBox->Controls->Add(this->lameButton);
            this->encoderBox->Controls->Add(this->flacLocation);
            this->encoderBox->Controls->Add(this->lameLocation);
            this->encoderBox->Controls->Add(this->flacButton);
            this->encoderBox->Controls->Add(this->LameLabel);
            this->encoderBox->Dock = System::Windows::Forms::DockStyle::Fill;
            this->encoderBox->Location = System::Drawing::Point(3, 3);
            this->encoderBox->Name = L"encoderBox";
            this->encoderBox->Size = System::Drawing::Size(426, 141);
            this->encoderBox->TabIndex = 13;
            this->encoderBox->TabStop = false;
            this->encoderBox->Text = L"Encoders";
            // 
            // panel1
            // 
            this->panel1->Controls->Add(this->okButton);
            this->panel1->Controls->Add(this->cancelButton);
            this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
            this->panel1->Location = System::Drawing::Point(226, 184);
            this->panel1->Name = L"panel1";
            this->panel1->Size = System::Drawing::Size(203, 29);
            this->panel1->TabIndex = 14;
            // 
            // panel2
            // 
            this->panel2->Controls->Add(this->encOptsButton);
            this->panel2->Dock = System::Windows::Forms::DockStyle::Fill;
            this->panel2->Location = System::Drawing::Point(226, 150);
            this->panel2->Name = L"panel2";
            this->panel2->Size = System::Drawing::Size(203, 28);
            this->panel2->TabIndex = 15;
            // 
            // encOptsButton
            // 
            this->encOptsButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
            this->encOptsButton->Location = System::Drawing::Point(92, 2);
            this->encOptsButton->Name = L"encOptsButton";
            this->encOptsButton->Size = System::Drawing::Size(108, 23);
            this->encOptsButton->TabIndex = 0;
            this->encOptsButton->Text = L"Encoding Options...";
            this->encOptsButton->UseVisualStyleBackColor = true;
            this->encOptsButton->Click += gcnew System::EventHandler(this, &OptionsWindow::encOptsButton_Click);
            // 
            // OptionsWindow
            // 
            this->AcceptButton = this->okButton;
            this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
            this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
            this->CancelButton = this->cancelButton;
            this->ClientSize = System::Drawing::Size(432, 216);
            this->Controls->Add(this->tableLayoutPanel1);
            this->Name = L"OptionsWindow";
            this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
            this->Text = L"Options";
            this->tableLayoutPanel1->ResumeLayout(false);
            this->tableLayoutPanel1->PerformLayout();
            this->encoderBox->ResumeLayout(false);
            this->encoderBox->PerformLayout();
            this->panel1->ResumeLayout(false);
            this->panel2->ResumeLayout(false);
            this->ResumeLayout(false);

        }
#pragma endregion

    public: void setOgg(String^ ogg){
                oggLocation->Text = ogg;
            }
    public: String^ getOgg(){
                return oggLocation->Text;
            }
    public: void setFlac(String^ flac){
                flacLocation->Text = flac;
            }
    public: String^ getFlac(){
                return flacLocation->Text;
            }
    public: void setLame(String^ lame){
                lameLocation->Text = lame;
            }
    public: String^ getLame(){
                return lameLocation->Text;
            }
    public: void setHide(bool hidden){
                hideCmd->Checked = hidden;
            }
    public: bool getHide(){
                return hideCmd->Checked;
            }
	public: String^ getEncoderStr(){
				return encoderStr;
			}
	public: int getEncoder(){
				return encoderChoice;
			}
    private: System::Void okButton_Click(System::Object^  sender, System::EventArgs^  e) {
                 this->Close();
             }
    private: System::Void oggButton_Click(System::Object^  sender, System::EventArgs^  e) {
                 OpenFileDialog^ ofd = gcnew OpenFileDialog();
                 ofd->Filter = "Executable Files (*.exe)|*.exe";
                 if(ofd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
                     oggLocation->Text = ofd->FileName;
                 }
             }
    private: System::Void flacButton_Click(System::Object^  sender, System::EventArgs^  e) {
                 OpenFileDialog^ ofd = gcnew OpenFileDialog();
                 ofd->Filter = "Executable Files (*.exe)|*.exe";
                 if(ofd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
                     flacLocation->Text = ofd->FileName;
                 }
             }
    private: System::Void lameButton_Click(System::Object^  sender, System::EventArgs^  e) {
                 OpenFileDialog^ ofd = gcnew OpenFileDialog();
                 ofd->Filter = "Executable Files (*.exe)|*.exe";
                 if(ofd->ShowDialog() != Windows::Forms::DialogResult::Cancel){
                     lameLocation->Text = ofd->FileName;
                 }
             }
    private: System::Void resetButton_Click(System::Object^  sender, System::EventArgs^  e) {
                 oggLocation->Text = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\oggenc.exe";
                 flacLocation->Text = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\flac.exe";
                 lameLocation->Text = System::IO::Path::GetDirectoryName(Application::ExecutablePath) + "\\lame.exe";
             }
    private: System::Void encOptsButton_Click(System::Object^  sender, System::EventArgs^  e) {
                 EncoderOptions^ eo = gcnew EncoderOptions();
				 Windows::Forms::DialogResult dr = eo->ShowDialog();
                 if(dr != Windows::Forms::DialogResult::Cancel){
					 encoderStr = eo->toString();
					 encoderChoice = eo->getEncoder();
                 }
             }
    };
}
