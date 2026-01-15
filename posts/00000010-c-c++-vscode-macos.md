# C y C++ en VS Code (MacOS)

Tener instalado un compilador de C y C++ (Clang en el caso de MacOS).

Instalar la extensión C/C++ Extension Pack, aunque no es obligatoria. Se puede instalar solo la extensión C/C++.

Instalar ClangFormat y la extensión Clang-Format.

brew install clang-format

Contenido del archivo `.vscode/settings.json` para formatear automáticamente al guardar:

{
"[c]": {
"editor.defaultFormatter": "xaver.clang-format",
"editor.formatOnSave": true,
"editor.wordBasedSuggestions": "off",
"editor.semanticHighlighting.enabled": true,
"editor.stickyScroll.defaultModel": "foldingProviderModel",
"editor.suggest.insertMode": "replace",
},
"[cpp]": {
"editor.defaultFormatter": "xaver.clang-format",
"editor.formatOnSave": true,
"editor.wordBasedSuggestions": "off",
"editor.semanticHighlighting.enabled": true,
"editor.stickyScroll.defaultModel": "foldingProviderModel",
"editor.suggest.insertMode": "replace"
}
}

.vscode/launch.json
{
"configurations": [
{
"name": "C/C++: clang++ build and debug active file",
"type": "cppdbg",
"request": "launch",
"program": "${fileDirname}/build/debug/${fileBasenameNoExtension}",
"args": [],
"stopAtEntry": false,
"cwd": "${fileDirname}",
"environment": [],
"externalConsole": true,
"MIMode": "lldb",
"preLaunchTask": "C/C++: clang++ build active file"
}
],
"version": "2.0.0"
}

https://github.com/microsoft/vscode-cpptools
https://github.com/microsoft/vscode-cmake-tools
https://clang.llvm.org/docs/ClangFormat.html
https://formulae.brew.sh/formula/clang-format#default
https://github.com/xaverh/vscode-clang-format
https://code.visualstudio.com/docs/cpp/launch-json-reference
