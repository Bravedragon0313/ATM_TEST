#!/usr/bin/env bash
set -e

echo "Stopping atm_base processes and clearing their logs..."
supervisorctl stop atm_base-audio atm_base-browser atm_base-machine atm_base-updater atm_base-watchdog
supervisorctl clear atm_base-audio atm_base-browser atm_base-machine atm_base-updater atm_base-watchdog

echo "Removing atm_base-machine persistent data..."
rm -rf /opt/atm_base-machine/data/connection_info.json \
       /opt/atm_base-machine/data/client.pem \
       /opt/atm_base-machine/data/client.key \
       /opt/atm_base-machine/data/machine.log \
       /opt/atm_base-machine/data/u2f.json \
       /opt/atm_base-machine/data/tx-db \
       /opt/atm_base-machine/data/operator-info.json \

if [ -d "/home/machine" ]; then
  touch /home/machine/.bash_logout
  echo "history -c" > /home/machine/.bash_logout
fi

if [ -d "/home/debian" ]; then
  touch /home/debian/.bash_logout
  echo "history -c" > /home/debian/.bash_logout
fi

touch /root/.bash_logout
echo "history -c" > /root/.bash_logout

echo > /etc/udev/rules.d/70-persistent-net.rules

echo "All done!"

