export default function useApiUrl() {
  return process.env.REACT_APP_API_HOST
    ? process.env.REACT_APP_API_HOST
    : "http://localhost:5206";
}
