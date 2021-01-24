// 05Native.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <windows.h>

CRITICAL_SECTION critSec;
BOOL bInitialized=FALSE;

extern "C"
{
	__declspec(dllexport) void InitBuffer(BYTE* ptr, INT size);

	__declspec(dllexport) VOID InitBuffer(BYTE* ptr, INT size)
	{
		Sleep(2000);
		for(int i=0; i<255; i++)
		{
			ptr[i]=i;
		}
	}

	__declspec(dllexport) VOID Init()
	{
		if(!bInitialized)
		{
			InitializeCriticalSection(&critSec);
			bInitialized=TRUE;
		}
	}

	__declspec(dllexport) VOID Process(BYTE* ptr)
	{
		EnterCriticalSection(&critSec);

		//
		// Process inbound data
		//  
	}

	__declspec(dllexport) VOID UnInit()
	{
		if(bInitialized)
		{
			EnterCriticalSection(&critSec);
			//
			// Do some work
			// 
			LeaveCriticalSection(&critSec);
			DeleteCriticalSection(&critSec);
			bInitialized=FALSE;
		}
	}
}