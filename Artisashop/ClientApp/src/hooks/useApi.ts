import {Configuration} from "api";
import useApiUrl from "./useApiUrl";

/**
 * Returns a configured instance of the API.
 * @param type the type of the API to return
 * @example `const api = useApi(AccountApi)`
 */
const useApi = <T,>(type: { new(config: Configuration) : T;}) : T => {
  const apiUrl = useApiUrl();
  const config = new Configuration({ basePath: apiUrl });
  // eslint-disable-next-line new-cap
  return new type(config);
}


export default useApi;
