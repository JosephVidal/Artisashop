import {Configuration} from "../api";
import { REACT_APP_API_URL } from "../conf";
/**
 * Returns a configured instance of the API.
 * @param Api the type of the API to return
 * @example `const api = useApi(AccountApi)`
 */
const useApi = <T,>(Api: { new(config: Configuration) : T;}) : T => {
  const apiUrl = REACT_APP_API_URL;
  const config = new Configuration({ basePath: apiUrl });
  return new Api(config);
}

export default useApi;
