export default function useApiUrl() {
  if (process.env.REACT_APP_ASPNETCORE_HTTPS_PORT) {
    return `https://localhost:${process.env.REACT_APP_ASPNETCORE_HTTPS_PORT}`;
  }
  if (process.env.REACT_APP_ASPNETCORE_URLS) {
    return process.env.REACT_APP_ASPNETCORE_URLS.split(";")[0];
  }
  return "http://localhost:5138";
}
