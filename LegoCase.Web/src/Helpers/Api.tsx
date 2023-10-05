export async function get<TResponse>(url: string) : Promise<TResponse> {
    const response = await fetch(url);
    const json = response.json();
    return json as TResponse;
}