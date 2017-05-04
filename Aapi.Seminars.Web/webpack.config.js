'use strict';

var webpack = require('webpack');

module.exports = {
    entry: {
        'polyfills': './app/polyfills.ts',
        'vendor': './app/vendor.ts',
        'aapi-seminars': './app/main.ts'
    },
    output: {
        filename: 'wwwroot/js/[name].js'
    },
    resolve: {
        extensions: ['.js', '.ts']
    },
    devtool: 'source-map',
    module: {
        loaders: [
            {
                test: /\.ts/,
                loaders: ['awesome-typescript-loader', 'angular2-template-loader']
            },
            {
                test: /\.scss$/,
                exclude: /node_modules/,
                loaders: ['raw-loader', 'sass-loader']
            },
            {
                test: /\.css$/,
                include: /node_modules/,
                loaders: ['style-loader', 'css-loader']
            },
            {
                test: /\.html$/,
                loaders: ['raw-loader']
            }
        ]
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin(),
        new webpack.ContextReplacementPlugin(/angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/)
    ]
};