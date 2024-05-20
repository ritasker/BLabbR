module.exports = {
  content: [
    './**/*.razor'
  ],
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["forest"],
  },
}
