import { useEffect, useState } from "react";

export function useForm(initialValues, submitHandlerCallback, reinitializeForm = false) {
    const [values, setValues] = useState(initialValues);

    useEffect(() => {
        if (reinitializeForm) {
            setValues(initialValues);
        };
    }, [initialValues, reinitializeForm]);

    const changeHandler = (e) => {
        setValues(prevState => ({
            ...prevState,
            [e.target.name]: e.target.type === 'checkbox'
                ? e.target.checked
                : e.target.value
        }));
    };

    const submitHandler = (e) => {
        e.preventDefault();

        submitHandlerCallback(values);
    };

    return {
        values,
        changeHandler,
        submitHandler,
    };
}
