// FlacSquisher.cpp : main project file.

#include "stdafx.h"
#include "FlacToPortable.h"

using namespace FlacSquisher;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// Enabling Windows XP visual effects before any controls are created
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// Create the main window and run it
	Application::Run(gcnew FlacToPortable());
	return 0;
}
