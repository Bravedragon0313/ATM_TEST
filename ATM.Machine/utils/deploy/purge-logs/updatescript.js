'use strict';

var cp = require('child_process');
var async = require('./async');
var report = require('./report').report;

const hardwareCode = process.argv[2].toLowerCase();
var TIMEOUT = 10000;

let purgeCommand = null
if (hardwareCode === 'aaeon')
  purgeCommand = 'rm /var/lib/atm_base-machine/log/*; rm /var/lib/atm_base-machine/tx-db/*'
else if (hardwareCode === 'ssuboard' || hardwareCode === 'upboard')
  purgeCommand = 'rm /opt/atm_base-machine/data/log/*; rm /opt/atm_base-machine/data/tx-db/*'
else purgeCommand = ''

function command(cmd, cb) {
  cp.exec(cmd, {timeout: TIMEOUT}, function(err) {
    cb(err);
  });
}

async.series([

  async.apply(command, purgeCommand),
  async.apply(report, null, 'finished.')
], function(err) {
  if (err) throw err;
});
