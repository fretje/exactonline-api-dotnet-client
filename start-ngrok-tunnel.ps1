# On the ngrok website, you can claim a free static domain.
# Before using this script, set a global environment variable
# 'NGROK_DOMAIN' with the name of that domain. i.e.:
#
#     setx NGROK_DOMAIN unique-poodle-enhanced.ngrok-free.app
#
# This way, your ngrok tunnel will always have that same name.

ngrok http --domain=$env:NGROK_DOMAIN 5000
