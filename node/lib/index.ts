export interface IProxy {
    server: string;
    username?: string | undefined;
    password?: string | undefined;
}

export interface ISolveOptions {
    type: 'hcaptcha' | 'recaptcha' | 'funcaptcha';
    url: string;
    site_key: string;
    proxy?: IProxy;
}

export interface ICaptureUser {
    username: string;
    credit: number;
}

async function importFetch() {
    // stupid hack to get around typescript transpiling imports to require() even when it's not supported
    return (await new Promise<any>(resolve => {
        eval('import("node-fetch").then(resolve)');
    })).default;
}

function getAPIUrl(port: number, endpoint: string) {
    return 'http://localhost:' + port + endpoint;
}

async function handleResponse(resp: Response) {
    const body = await (resp.json() as Promise<any>);

    if (resp.status >= 400) throw new Error(resp.status + ' ' + body.message);
    else return body;
}

export async function getUser(clientPort: number): Promise<ICaptureUser> {
    const resp = await (await importFetch())(getAPIUrl(clientPort, '/user'));
    return await handleResponse(resp);
}

export async function solveCaptcha(clientPort: number, options: ISolveOptions): Promise<string> {
    const resp = await (await importFetch())(getAPIUrl(clientPort, '/solve'), {
        method: 'POST',
        body: JSON.stringify(options),
        headers: { 'content-type': 'application/json' }
    });
    
    return (await handleResponse(resp)).solution;
}