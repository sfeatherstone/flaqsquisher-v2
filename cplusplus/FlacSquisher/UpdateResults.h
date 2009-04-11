#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace FlacSquisher {

	/// <summary>
	/// Summary for UpdateResults
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class UpdateResults : public System::Windows::Forms::Form
	{
	public:
		UpdateResults(void)
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
		~UpdateResults()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  results;
	private: System::Windows::Forms::Button^  OKbutton;
	private: System::Windows::Forms::Button^  CancelButton;
	protected: 





	protected: 

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
			this->results = (gcnew System::Windows::Forms::Label());
			this->OKbutton = (gcnew System::Windows::Forms::Button());
			this->CancelButton = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// results
			// 
			this->results->AutoSize = true;
			this->results->Location = System::Drawing::Point(12, 9);
			this->results->Name = L"results";
			this->results->Size = System::Drawing::Size(35, 13);
			this->results->TabIndex = 0;
			this->results->Text = L"label1";
			// 
			// OKbutton
			// 
			this->OKbutton->Location = System::Drawing::Point(43, 139);
			this->OKbutton->Name = L"OKbutton";
			this->OKbutton->Size = System::Drawing::Size(75, 23);
			this->OKbutton->TabIndex = 1;
			this->OKbutton->Text = L"Yes";
			this->OKbutton->UseVisualStyleBackColor = true;
			this->OKbutton->Click += gcnew System::EventHandler(this, &UpdateResults::OKbutton_Click);
			// 
			// CancelButton
			// 
			this->CancelButton->DialogResult = System::Windows::Forms::DialogResult::Cancel;
			this->CancelButton->Location = System::Drawing::Point(135, 139);
			this->CancelButton->Name = L"CancelButton";
			this->CancelButton->Size = System::Drawing::Size(75, 23);
			this->CancelButton->TabIndex = 2;
			this->CancelButton->Text = L"Cancel";
			this->CancelButton->UseVisualStyleBackColor = true;
			this->CancelButton->Click += gcnew System::EventHandler(this, &UpdateResults::CancelButton_Click);
			// 
			// UpdateResults
			// 
			this->AcceptButton = this->OKbutton;
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(261, 174);
			this->ControlBox = false;
			this->Controls->Add(this->CancelButton);
			this->Controls->Add(this->OKbutton);
			this->Controls->Add(this->results);
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"UpdateResults";
			this->Text = L"Update check";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void CancelButton_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->DialogResult = Windows::Forms::DialogResult::Cancel;
				 this->Close();
			 }
	public:  String^ getResults(){
				 return results->Text;
			 }
			 void setResults(String^ res){
				 results->Text = res;
			 }
	private: System::Void OKbutton_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->DialogResult = Windows::Forms::DialogResult::Yes;
				 this->Close();
			 }
};
}
