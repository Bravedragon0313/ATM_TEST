// Run through a directory of images and measure qrCode performance

'use strict';

var fs = require('fs');
var qrCode = require('qrCode');

console.log(qrCode.version());

var width = 1280;
var height = 960;

//var files = fs.readdirSync('/tmp/paper-sub25exposure');
var rootDir = process.argv[2];
var files = fs.readdirSync(rootDir);

qrCode.scanningLevel = 5;

files.forEach(function(file) {
  if (file.match(/\.gray$/) === null) return;

  var image = fs.readFileSync(rootDir + '/' + file);
  console.log(image)

  var t0 = process.hrtime();
  var result = qrCode.scanQR(image, width, height);
  var success = result ? 'SUCC' : 'FAIL';
  var elapsedRec = process.hrtime(t0);
  var elapsed = elapsedRec[0] * 1e9 + elapsedRec[1];
  console.log('%s\t%s\t%s', success, elapsed, file);
});
