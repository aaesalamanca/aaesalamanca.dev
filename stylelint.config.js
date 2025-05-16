// https://stylelint.io/user-guide/get-started#using-a-custom-syntax-directly
// https://github.com/ota-meshi/stylelint-config-html?tab=readme-ov-file#book-usage
/** @type {import('stylelint').Config} */
export default {
  extends: ["stylelint-config-standard", "stylelint-config-html/astro"],
};
