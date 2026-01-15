# Iniciar proyecto de Astro

npm create astro@latest

tsconfig.json
{
"extends": "astro/tsconfigs/strictest",
"include": [".astro/types.d.ts", "**/*"],
"exclude": ["dist"]
}

package.json
{
"scripts": {
"build": "astro build",
"build": "astro check && astro build",
},
}

npm install --save-dev --save-exact prettier

.prettierrc.json
{
"semi": false,
"singleQuote": true
}

.vscode/settings.json
{
"[astro]": {
"editor.defaultFormatter": "astro-build.astro-vscode",
"editor.formatOnSave": true
},
"[javascript][html][css][markdown][json][jsonc][yaml][graphql][xml][typescript]": {
"editor.defaultFormatter": "esbenp.prettier-vscode",
"editor.formatOnSave": true
}
}

npm install --save-dev eslint@latest @eslint/js@latest eslint-plugin-astro @typescript-eslint/parser eslint-plugin-jsx-a11y

eslint.config.js
import js from '@eslint/js'
import eslintPluginAstro from 'eslint-plugin-astro'

export default [
// add more generic rule sets here, such as:
js.configs.recommended,
...eslintPluginAstro.configs['jsx-a11y-strict'],
{
rules: {
// override/add rules settings here, such as:
// "astro/no-set-html-directive": "error"
},
},
]

.vscode/settings.json
{
"[astro]": {
"editor.defaultFormatter": "astro-build.astro-vscode",
"editor.formatOnSave": true
},
"[javascript][html][css][markdown][json][jsonc][yaml][graphql][xml][typescript]": {
"editor.defaultFormatter": "esbenp.prettier-vscode",
"editor.formatOnSave": true
},
"eslint.validate": [
"javascript",
"astro", // Enable .astro
"typescript" // Enable .ts
]
}

npm install --save-dev stylelint stylelint-config-standard postcss-html stylelint-config-html

.stylelintrc.json
{
"extends": [
"stylelint-config-standard",
"stylelint-config-html/html",
"stylelint-config-html/astro"
]
}

.vscode/settings.json
{
"[astro]": {
"editor.defaultFormatter": "astro-build.astro-vscode",
"editor.formatOnSave": true
},
"[javascript][html][css][markdown][json][jsonc][yaml][graphql][xml][typescript]": {
"editor.defaultFormatter": "esbenp.prettier-vscode",
"editor.formatOnSave": true
},
"eslint.validate": [
"javascript",
"astro", // Enable .astro
"typescript" // Enable .ts
],
"stylelint.validate": [
// ↓ Add "html" language.
"html",
// ↓ Add "astro" language.
"astro"
]
}

npm install --save bootstrap @popperjs/core @types/bootstrap
npm install --save-dev sass

scss/styles.scss
// Import all of Bootstrap’s CSS
@import "bootstrap/scss/bootstrap";

## src/layouts/Layout.astro

// Import our custom CSS
import '../scss/styles.scss'

import Favicons from '../components/Favicons.astro'
import Header from '../components/Header.astro'
import Footer from '../components/Footer.astro'

const { title } = Astro.props
const siteTitle = title
? `${title} | Alejandro Estornell`
: 'Alejandro Estornell | Desarrollador de software con 5 años de experiencia especializado en .NET'

---

<!doctype html>
<html lang="es-ES">
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>{siteTitle}</title>
    <Favicons />
  </head>

  <body class="container-fluid px-3 px-md-5">
    <Header />
    <main class="my-4">
      <slot />
    </main>
    <Footer />
    <script>
      // Import all of Bootstrap’s JS
      import 'bootstrap'
    </script>
  </body>
</html>

https://docs.astro.build/en/install-and-setup/
https://docs.astro.build/en/basics/project-structure/
https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode
https://docs.astro.build/en/guides/typescript/
https://docs.astro.build/en/editor-setup/
https://prettier.io/docs/install
https://prettier.io/docs/configuration
https://marketplace.visualstudio.com/items?itemName=astro-build.astro-vscode
https://eslint.org
https://marketplace.visualstudio.com/items?itemName=dbaeumer.vscode-eslint
https://ota-meshi.github.io/eslint-plugin-astro/
https://ota-meshi.github.io/eslint-plugin-astro/user-guide/
https://eslint.org/docs/latest/use/getting-started
https://eslint.org/docs/latest/use/configure/configuration-files
https://stylelint.io
https://stylelint.io/user-guide/get-started
https://stylelint.io/user-guide/configure
https://marketplace.visualstudio.com/items?itemName=stylelint.vscode-stylelint
https://github.com/ota-meshi/stylelint-config-html
https://getbootstrap.com
https://getbootstrap.com/docs/5.3/getting-started/download/
https://getbootstrap.com/docs/5.3/getting-started/vite/
https://github.com/DefinitelyTyped/DefinitelyTyped
https://docs.astro.build/en/guides/client-side-scripts/
