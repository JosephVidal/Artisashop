import useApiUrl from "./useApiUrl";
import {Configuration} from "../api";

/**
 * Returns a configured instance of the API.
 * @param type the type of the API to return
 * @example `const api = useApi(AccountApi)`
 */
const useApi = <T,>(type: { new(config: Configuration) : T;}) : T => {
  const apiUrl = useApiUrl();
  const config = new Configuration({ basePath: apiUrl });
  return new type(config);
}


export default useApi;
