# Chuleta de Odin

## Código
```odin
// Define un paquete.
package odin_cheatsheet

// Importar librerías.
import "core:fmt"

// Declarar el procedimiento `main`.
main :: proc() {
	// Invocar un procedimiento definido en `fmt`.
	fmt.println("¡Hola, mundo!")
	
	// Invocar un procedimiento.
	returned_value := add_three(int)
}

// Declarar procedimiento.
add_three :: proc(number: int) -> int {
	return number + 3
}
```

## Opciones comunes del compilador
```zsh
# Compila en un paquete todos los ficheros `.odin`
# del directorio actual, crea el ejecutable a partir
# del paquete y lo inicia.
# 
# Borra el ejecutable cuando este ha finalizado.
odin run .
# Compila en un paquete todos los ficheros `.odin`
# del directorio actual, crea el ejecutable a partir
# del paquete y lo inicia.
# 
# No borra el ejecutable cuando este ha finalizado.
odin run . -keep-executable
# Compila en un paquete todos los ficheros `.odin`
# del directorio actual, crea el ejecutable a partir
# del paquete y lo inicia.
# 
# Borra el ejecutable cuando este ha finalizado.
# 
# Identifica como error cualquier punto y coma
# innecesario que detecte.
odin run . -vet-semicolon
# Compila en un paquete todos los ficheros `.odin`
# del directorio actual, crea el ejecutable a partir
# del paquete y lo inicia.
# 
# Borra el ejecutable cuando este ha finalizado.
# 
# Realiza comprobaciones de estilo que, si no se cumplen,
# identificará como errores.
odin run . -vet
# Compila en un paquete todos los ficheros `.odin`
# del directorio actual, crea el ejecutable a partir
# del paquete y lo inicia.
# 
# Borra el ejecutable cuando este ha finalizado.
# 
# Realiza comprobaciones de estilo que, si no se cumplen,
# identificará como errores. También impone el estilo
# de código utilizado en `core`.
odin run . -vet -strict-style
# Compila en un paquete el fichero indicado, crea
# el ejecutable a partir del paquete y lo inicia.
# 
# Borra el ejecutable cuando este ha finalizado.
odin run odin_cheatsheet.odin -file

# Compila en un paquete todos los ficheros `.odin`
# del directorio actual y crea el ejecutable a partir
# del paquete sin iniciarlo.
odin build .
```
