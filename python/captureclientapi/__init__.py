import requests

def _get_url(port, endpoint):
    return 'http://localhost:' + str(client_port) + '/solve'

def get_user(client_port):
    resp = requests.post(_get_url(client_port, '/user'), json=data)
    body = resp.json()

    if resp.status_code >= 400:
        raise Exception(resp.status_code + ' ' + body['message'])

    return body

def solve(client_port, captcha_type, url, site_key, proxy_server = None, proxy_username = None, proxy_password = None):
    data = {
        'type': captcha_type,
        'url': url,
        'site_key': site_key
    }

    if proxy_server is not None:
        data['proxy'] = {
            'server': proxy_server,
            'username': proxy_username,
            'password': proxy_password
        }

    resp = requests.post(_get_url(client_port, '/solve'), json=data)
    body = resp.json()

    if resp.status_code >= 400:
        raise Exception(resp.status_code + ' ' + body['message'])

    return body['solution']
