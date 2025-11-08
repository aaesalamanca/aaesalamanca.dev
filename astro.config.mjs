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
  site: 'https://aaesalamanca.github.io',
})
