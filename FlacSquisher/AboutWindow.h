#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace FlacSquisher {

	/// <summary>
	/// Summary for AboutWindow
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class AboutWindow : public System::Windows::Forms::Form
	{
	public:
		AboutWindow(void)
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
		~AboutWindow()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  NameLabel;
	private: System::Windows::Forms::Label^  CRLabel;
	private: System::Windows::Forms::LinkLabel^  URLLabel;
	private: System::Windows::Forms::Button^  okButton;

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
			this->NameLabel = (gcnew System::Windows::Forms::Label());
			this->CRLabel = (gcnew System::Windows::Forms::Label());
			this->URLLabel = (gcnew System::Windows::Forms::LinkLabel());
			this->okButton = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// NameLabel
			// 
			this->NameLabel->AutoSize = true;
			this->NameLabel->Location = System::Drawing::Point(104, 9);
			this->NameLabel->Name = L"NameLabel";
			this->NameLabel->Size = System::Drawing::Size(68, 13);
			this->NameLabel->TabIndex = 0;
			this->NameLabel->Text = L"FlacSquisher";
			this->NameLabel->TextAlign = System::Drawing::ContentAlignment::TopCenter;
			// 
			// CRLabel
			// 
			this->CRLabel->AutoSize = true;
			this->CRLabel->Location = System::Drawing::Point(74, 31);
			this->CRLabel->Name = L"CRLabel";
			this->CRLabel->Size = System::Drawing::Size(116, 13);
			this->CRLabel->TabIndex = 1;
			this->CRLabel->Text = L"© Michael Brown 2008";
			// 
			// URLLabel
			// 
			this->URLLabel->AutoSize = true;
			this->URLLabel->Location = System::Drawing::Point(33, 55);
			this->URLLabel->Name = L"URLLabel";
			this->URLLabel->Size = System::Drawing::Size(225, 13);
			this->URLLabel->TabIndex = 2;
			this->URLLabel->TabStop = true;
			this->URLLabel->Text = L"https://sourceforge.net/projects/flacsquisher/";
			// 
			// okButton
			// 
			this->okButton->Location = System::Drawing::Point(107, 81);
			this->okButton->Name = L"okButton";
			this->okButton->Size = System::Drawing::Size(75, 23);
			this->okButton->TabIndex = 3;
			this->okButton->Text = L"OK";
			this->okButton->UseVisualStyleBackColor = true;
			// 
			// AboutWindow
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->CancelButton = this->okButton;
			this->ClientSize = System::Drawing::Size(292, 116);
			this->Controls->Add(this->okButton);
			this->Controls->Add(this->URLLabel);
			this->Controls->Add(this->CRLabel);
			this->Controls->Add(this->NameLabel);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
			this->MaximizeBox = false;
			this->MinimizeBox = false;
			this->Name = L"AboutWindow";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
			this->Text = L"About FlacSquisher";
			this->TopMost = true;
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	};
}
