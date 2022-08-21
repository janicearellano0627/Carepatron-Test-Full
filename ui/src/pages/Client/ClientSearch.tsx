import "../../styles/clientSearch.css"
import { memo, useContext, useEffect, useState } from "react";

export interface IProps {
}

export default function ClientSearch({ handleChange }) {
    const [inputValue, setInputValue] = useState("");
    const onChangeHandler = event => {
        setInputValue(event.target.value);
    };

    return (
        <div>
            <input id="search-box" name="searchquery" type="text" placeholder="Search" value={inputValue} onChange={onChangeHandler} />
            <input id="search-btn" value="Search" type="submit" onClick={() => handleChange(inputValue)} />
        </div>
    );
};
