const util = require('util')
const PiCamera = require('pi-camera');

const cam = new PiCamera.Camera('/dev/video0')
console.log(util.inspect(cam.formats, {colors: true, depth: null}))
