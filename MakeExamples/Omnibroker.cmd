Class CommandShell
	Brief "Command Line Parser Generator"

	Type NewFile			"file"
	Type ExistingFile		"file"
	Type Flag				"flag"


	Command Generate "generate"
		DefaultCommand

		Option Connection "Connection" NewFile
			Default xml

		Option Query "Query" NewFile
			Default xml

		Option MutualAuth "MutualAuth" NewFile
			Default xml