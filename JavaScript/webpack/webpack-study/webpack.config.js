const path = require('path');
const webpack = require('webpack');

module.exports = {
    entry: './src/main.js',
    mode: 'production',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'dist')
    },
    devServer: {
        open: true,
        port: 3000,
        contentBase: 'src',
        hot: true
    },

    plugins: [
        new webpack.HotModuleReplacementPlugin()
    ],

    module: {
        rules: [
            { test: /\.css$/, use: ['style-loader', 'css-loader'] },
            { test: /\.(jpg|png|gif)$/, use: ['url-loader?limit=31'] },
        ]
    }

};

