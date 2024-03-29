module.exports = {
  content: [
    './Components/Pages/**/*.razor',
    './Components/Layout/**/*.razor'
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
