export default function useApiUrl() {
    return import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
        ? `https://localhost:${import.meta.env.VITE_ASPNETCORE_HTTPS_PORT}`
        : import.meta.env.VITE_ASPNETCORE_URLS
            ? import.meta.env.VITE_ASPNETCORE_URLS.split(";")[0]
            : "http://localhost:5138";
}