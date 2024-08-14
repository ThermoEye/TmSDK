#pragma once

#include "TmExport.hxx"

#include <string>
#include <exception>
#include <stdexcept>

namespace TmSDK
{
	#pragma warning(disable:4275)

	/// <summary>
	/// Class representing an exception specific to the TmSDK library.
	/// </summary>
	class DLL_EXPORTS TmException : public std::exception
	{
	public:
		TmException(const std::string& error);
		~TmException() noexcept {}
		const char* what() const noexcept override;
	};

	#pragma warning(default:4275)
}


