/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      fontFamily: {
        blackfort: ["MyBlackford-Regular"],
        sans: ['Helvetica', 'Arial', 'sans-serif'],
      },
      colors: {
        light: "#F4EBE1",
        richblack: "#141C26",
        primary: "#5A202E",
        saddlebrown: "#8B4513",
        secondary: "#DC6D04",
        tertiary: "#79B8F6",
        deeptaupe: "#88666f",
        bistre: "#452A16",
        queenblue: "#536a86",
        frenchskyblue: "#79B8F6",
      },
    },
  },
  plugins: [],
};
