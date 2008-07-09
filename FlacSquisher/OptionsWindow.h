#pragma once

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
			this->SuspendLayout();
			// 
			// OggencLabel
			// 
			this->OggencLabel->AutoSize = true;
			this->OggencLabel->Location = System::Drawing::Point(12, 9);
			this->OggencLabel->Name = L"OggencLabel";
			this->OggencLabel->Size = System::Drawing::Size(70, 13);
			this->OggencLabel->TabIndex = 0;
			this->OggencLabel->Text = L"Ogg Encoder";
			// 
			// oggLocation
			// 
			this->oggLocation->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->oggLocation->Location = System::Drawing::Point(12, 25);
			this->oggLocation->Name = L"oggLocation";
			this->oggLocation->Size = System::Drawing::Size(337, 20);
			this->oggLocation->TabIndex = 1;
			// 
			// oggButton
			// 
			this->oggButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->oggButton->Location = System::Drawing::Point(355, 23);
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
			this->FlacLabel->Location = System::Drawing::Point(12, 48);
			this->FlacLabel->Name = L"FlacLabel";
			this->FlacLabel->Size = System::Drawing::Size(71, 13);
			this->FlacLabel->TabIndex = 3;
			this->FlacLabel->Text = L"Flac Decoder";
			// 
			// flacLocation
			// 
			this->flacLocation->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->flacLocation->Location = System::Drawing::Point(12, 64);
			this->flacLocation->Name = L"flacLocation";
			this->flacLocation->Size = System::Drawing::Size(337, 20);
			this->flacLocation->TabIndex = 4;
			// 
			// flacButton
			// 
			this->flacButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->flacButton->Location = System::Drawing::Point(355, 62);
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
			this->LameLabel->Location = System::Drawing::Point(12, 87);
			this->LameLabel->Name = L"LameLabel";
			this->LameLabel->Size = System::Drawing::Size(76, 13);
			this->LameLabel->TabIndex = 6;
			this->LameLabel->Text = L"Lame Encoder";
			// 
			// lameLocation
			// 
			this->lameLocation->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->lameLocation->Location = System::Drawing::Point(12, 103);
			this->lameLocation->Name = L"lameLocation";
			this->lameLocation->Size = System::Drawing::Size(337, 20);
			this->lameLocation->TabIndex = 7;
			// 
			// lameButton
			// 
			this->lameButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->lameButton->Location = System::Drawing::Point(355, 101);
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
			this->cancelButton->Location = System::Drawing::Point(355, 146);
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
			this->okButton->Location = System::Drawing::Point(274, 146);
			this->okButton->Name = L"okButton";
			this->okButton->Size = System::Drawing::Size(75, 23);
			this->okButton->TabIndex = 10;
			this->okButton->Text = L"OK";
			this->okButton->UseVisualStyleBackColor = true;
			this->okButton->Click += gcnew System::EventHandler(this, &OptionsWindow::okButton_Click);
			// 
			// resetButton
			// 
			this->resetButton->Location = System::Drawing::Point(12, 146);
			this->resetButton->Name = L"resetButton";
			this->resetButton->Size = System::Drawing::Size(75, 23);
			this->resetButton->TabIndex = 11;
			this->resetButton->Text = L"Defaults";
			this->resetButton->UseVisualStyleBackColor = true;
			this->resetButton->Click += gcnew System::EventHandler(this, &OptionsWindow::resetButton_Click);
			// 
			// OptionsWindow
			// 
			this->AcceptButton = this->okButton;
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->CancelButton = this->cancelButton;
			this->ClientSize = System::Drawing::Size(442, 181);
			this->Controls->Add(this->resetButton);
			this->Controls->Add(this->okButton);
			this->Controls->Add(this->cancelButton);
			this->Controls->Add(this->lameButton);
			this->Controls->Add(this->lameLocation);
			this->Controls->Add(this->LameLabel);
			this->Controls->Add(this->flacButton);
			this->Controls->Add(this->flacLocation);
			this->Controls->Add(this->FlacLabel);
			this->Controls->Add(this->oggButton);
			this->Controls->Add(this->oggLocation);
			this->Controls->Add(this->OggencLabel);
			this->Name = L"OptionsWindow";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
			this->Text = L"OptionsWindow";
			this->ResumeLayout(false);
			this->PerformLayout();

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
};
}
