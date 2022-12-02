import { atomWithStorage } from "jotai/utils";

const tokenAtom = atomWithStorage<string | null>("token", null);

export default tokenAtom;
