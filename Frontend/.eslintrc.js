module.exports = {
  root: true,
  parser: '@typescript-eslint/parser',
  parserOptions: {
    tsconfigRootDir: __dirname,
    project: ['./tsconfig.json']
  },
  plugins: ['@typescript-eslint'],
  extends: ['eslint:recommended', 'plugin:@typescript-eslint/recommended-requiring-type-checking', 'airbnb', 'airbnb-typescript', 'prettier', 'plugin:storybook/recommended'],
  rules: {
    '@typescript-eslint/comma-dangle': 'off',
    '@typescript-eslint/no-use-before-define': 'off',
    '@typescript-eslint/lines-between-class-members': ['warn', 'always', {
      "exceptAfterSingleLine": true
    }],
    '@typescript-eslint/no-floating-promises': 'off',
    '@typescript-eslint/no-misused-promises': ['warn', {
      'checksVoidReturn': false
    }],
    '@typescript-eslint/no-unsafe-assignment': 'off',
    'import/prefer-default-export': 'off',
    'max-len': 'off',
    'implicit-arrow-linebreak': 'off',
    'function-paren-newline': 'off',
    'react/prop-types': 'off',
    'react/jsx-curly-newline': 'off',
    'react/sort-comp': 'off',
    'react/destructuring-assignment': 'off',
    'react/no-unused-prop-types': 'off',
    'react/require-default-props': 'off',
    'react/no-array-index-key': 'off',
    'react/function-component-definition': [2, {
      namedComponents: "arrow-function",
      unnamedComponents: "arrow-function"
    }],
    'jsx-a11y/click-events-have-key-events': 'off',
    'jsx-a11y/no-static-element-interactions': 'off',
    'jsx-a11y/label-has-associated-control': 'off',
    '@typescript-eslint/no-unused-vars': 'warn'
  }
};
