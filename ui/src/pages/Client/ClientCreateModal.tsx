import { SwitchLeftSharp } from '@mui/icons-material';
import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import { createClient } from "../../services/api";

export interface IProps {
    client: ICreateClient;
}

export default function ClientCreateModal(props) {

    const [firstNameValue, setfirstNameValue] = useState("");
    const [lastNameValue, setlastNameValue] = useState("");
    const [emailValue, setemailValue] = useState("");
    const [phoneValue, setphoneValue] = useState("");

    const onChangeHandler = event => {
        switch (event.target.name) {
            case "fname":
                setfirstNameValue(event.target.value);
                break;
            case "lname":
                setlastNameValue(event.target.value);
                break;
            case "phone":
                setphoneValue(event.target.value);
                break;
            case "email":
                setemailValue(event.target.value);
                break;
        }
    };


    function CreateNewClient() {
        const client: ICreateClient = {
            firstName: firstNameValue,
            lastName: lastNameValue,
            email: emailValue,
            phoneNumber: phoneValue
        };

        console.log("Client:", client);

        createClient(client).then((data) => {
            alert("Successfully Save!");
            clearValue();
            props.onCreateComplete();
        });
    }

    function clearValue() {
        setfirstNameValue("");
        setlastNameValue("");
        setphoneValue("");
        setemailValue("");
    }

    return (
        <Modal {...props} aria-labelledby="contained-modal-title-vcenter">
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Create new client
                </Modal.Title>
            </Modal.Header>
            <Modal.Body className="show-grid">
                <Container>
                    <Row>
                        <Col xs={12} md={12}>
                            First Name
                        </Col>
                        <Col xs={12} md={12}>
                            <div > <input id="fname" name="fname" type="text" placeholder="" value={firstNameValue} onChange={onChangeHandler} /></div>
                        </Col>
                    </Row>

                    <Row>
                        <Col xs={12} md={12}>
                            Last Name
                        </Col>
                        <Col xs={12} md={12}>
                            <div> <input id="lname" name="lname" type="text" placeholder="" value={lastNameValue} onChange={onChangeHandler} /></div>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={12} md={12}>
                            Phone Number
                        </Col>
                        <Col xs={12} md={12}>
                            <div> <input id="phone" name="phone" type="text" placeholder="" value={phoneValue} onChange={onChangeHandler} /></div>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={12} md={12}>
                            Email
                        </Col>
                        <Col xs={12} md={12}>
                            <div> <input id="email" name="email" type="text" placeholder="" value={emailValue} onChange={onChangeHandler} /></div>
                        </Col>
                    </Row>
                </Container>
            </Modal.Body>
            <Modal.Footer>
                <Button onClick={() => CreateNewClient()}>Create Client</Button>
            </Modal.Footer>
        </Modal>
    );
}