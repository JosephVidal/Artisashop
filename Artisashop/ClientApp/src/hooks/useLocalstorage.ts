import {useState} from "react";

type Setter<TModel> = (value: TModel | null | ((storedValue: TModel | null) => TModel)) => void;

export default function useLocalStorage<TModel>(key: string, initialValue: TModel | null): [(TModel | null), Setter<TModel>] {
    // State to store our value
    // Pass initial state function to useState so logic is only executed once
    const [storedValue, setStoredValue] = useState<TModel | null>(() => {
        if (typeof window === "undefined") {
            return initialValue;
        }

        try {
            // Get from local storage by key
            const item = window.localStorage.getItem(key);
            // Parse stored json or if none return initialValue
            return item ? JSON.parse(item) as TModel : initialValue;
        } catch (error) {
            // If error also return initialValue
            console.log(error);
            return initialValue;
        }
    });

    // Return a wrapped version of useState's setter function that ...
    // ... persists the new value to localStorage.
    const setValue: Setter<TModel> = value => {
        try {
            // Allow value to be a function so we have same API as useState
            const valueToStore =
                (value instanceof Function) ? value(storedValue) : value;
            // Save state
            setStoredValue(valueToStore);
            // Save to local storage
            if (typeof window !== "undefined") {
                window.localStorage.setItem(key, JSON.stringify(valueToStore));
            }
        } catch (error) {
            // A more advanced implementation would handle the error case
            console.log(error);
        }
    };

    return [storedValue, setValue];
}