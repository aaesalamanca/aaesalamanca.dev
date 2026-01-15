# Desplegar Astro en GitHub Pages y Porkbun

.github/workflows/deploy.yml
name: Deploy to GitHub Pages

on:

# Trigger the workflow every time you push to the `main` branch

# Using a different branch name? Replace `main` with your branch’s name

push:
branches: [ main ]

# Allows you to run this workflow manually from the Actions tab on GitHub.

workflow_dispatch:

# Allow this job to clone the repo and create a page deployment

permissions:
contents: read
pages: write
id-token: write

jobs:
build:
runs-on: ubuntu-latest
steps: - name: Checkout your repository using git
uses: actions/checkout@v5 - name: Install, build, and upload your site
uses: withastro/action@v5 # with: # path: . # The root location of your Astro project inside the repository. (optional) # node-version: 24 # The specific version of Node that should be used to build your site. Defaults to 22. (optional) # package-manager: pnpm@latest # The Node package manager that should be used to install dependencies and build your site. Automatically detected based on your lockfile. (optional) # build-cmd: pnpm run build # The command to run to build your site. Runs the package build script/task by default. (optional) # env: # PUBLIC_POKEAPI: 'https://pokeapi.co/api/v2' # Use single quotation marks for the variable value. (optional)

deploy:
needs: build
runs-on: ubuntu-latest
environment:
name: github-pages
url: ${{ steps.deployment.outputs.page_url }}
steps: - name: Deploy to GitHub Pages
id: deployment
uses: actions/deploy-pages@v4

astro.config.mjs
// @ts-check
import { defineConfig } from 'astro/config'

// https://astro.build/config
export default defineConfig({
vite: {
// Optional: Silence Sass deprecation warnings. See note below.
css: {
preprocessorOptions: {
scss: {
silenceDeprecations: [
'import',
'mixed-decls',
'color-functions',
'global-builtin',
],
},
},
},
},
prefetch: {
prefetchAll: true,
},
site: 'https://aaesalamanca.dev',
base: '/aaesalamanca.dev',
})

TXT | \_github-pages-challenge-aaesalamanca.aaesalamanca.dev | 91655bfd54a2e27f3870199daa23bf | 600

$ dig \_github-pages-challenge-aaesalamanca.aaesalamanca.dev +nostats +nocomments +nocmd TXT

A | aaesalamanca.dev | 185.199.108.153 | 600
A | aaesalamanca.dev | 185.199.109.153 | 600
A | aaesalamanca.dev | 185.199.110.153 | 600
A | aaesalamanca.dev | 185.199.111.153 | 600
AAAA | aaesalamanca.dev | 2606:50c0:8000::153 | 600
AAAA | aaesalamanca.dev | 2606:50c0:8001::153 | 600
AAAA | aaesalamanca.dev | 2606:50c0:8002::153 | 600
AAAA | aaesalamanca.dev | 2606:50c0:8003::153 | 600
CNAME | www.aaesalamanca.dev | aaesalamanca.github.io | 600

$ dig aaesalamanca.dev +noall +answer -t A
$ dig aaesalamanca.dev +noall +answer -t AAAA
$ dig www.aaesalamanca.dev +nostats +nocomments +nocmd

public/CNAME
www.aaesalamanca.dev

astro.config.mjs
// @ts-check
import { defineConfig } from 'astro/config'

// https://astro.build/config
export default defineConfig({
vite: {
// Optional: Silence Sass deprecation warnings. See note below.
css: {
preprocessorOptions: {
scss: {
silenceDeprecations: [
'import',
'mixed-decls',
'color-functions',
'global-builtin',
],
},
},
},
},
prefetch: {
prefetchAll: true,
},
site: 'https://aaesalamanca.dev',
})

https://docs.astro.build/en/guides/deploy/github/
https://docs.github.com/en/pages
https://docs.github.com/en/pages/configuring-a-custom-domain-for-your-github-pages-site/about-custom-domains-and-github-pages
https://docs.github.com/en/pages/configuring-a-custom-domain-for-your-github-pages-site/managing-a-custom-domain-for-your-github-pages-site
https://docs.github.com/en/pages/configuring-a-custom-domain-for-your-github-pages-site/verifying-your-custom-domain-for-github-pages
https://kb.porkbun.com/article/64-how-to-connect-your-domain-to-github-pages
https://kb.porkbun.com/article/231-how-to-add-dns-records-on-porkbun
https://kb.porkbun.com/article/33-how-long-will-it-take-for-changes-to-dns-to-show-up
