import { memo, useContext, useEffect, useRef, useState } from "react";
import { Paper, Typography } from "@mui/material";
import { StateContext } from "../../store/DataProvider";
import Page from "../../components/Page";
import ClientTable from "./ClientTable";
import { getClients } from "../../services/api";
import ClientSearch from "./ClientSearch";
import Button from 'react-bootstrap/Button';
import ClientCreateModal from "./ClientCreateModal";
import { Col, Row } from "react-bootstrap";
import { getClientFilter } from "../../services/api";


function Clients() {
  const { state, dispatch } = useContext(StateContext);
  const { clients } = state;
  const [modalShow, setModalShow] = useState(false);

  useEffect(() => {
    getClients().then((clients) =>
      dispatch({ type: "FETCH_ALL_CLIENTS", data: clients })
    );
  }, [dispatch]);

  function clientSearchQuery(filter: string) {
    getClientFilter(filter.trim()).then((clients) =>
      dispatch({ type: "FETCH_ALL_CLIENTS", data: clients })
    );
  }

  function CreateCompletedHandler() {
    setModalShow(false);
    getClients().then((clients) =>
      dispatch({ type: "FETCH_ALL_CLIENTS", data: clients })
    );
  }

  return (
    <Page>
      <Typography variant="h4" sx={{ textAlign: "start" }}>
        Clients
      </Typography>
      <div className="row">
        <div className="searchDiv">

        </div>
        <div className="addButtonDiv">


        </div>
      </div>
      <Row>
        <Col xs={6} md={6}>
          <ClientSearch handleChange={clientSearchQuery} />
        </Col>
        <Col xs={6} md={6}>
          <Button variant="primary" onClick={() => setModalShow(true)}>
            Create Client
          </Button>
          <ClientCreateModal
            show={modalShow}
            onCreateComplete={CreateCompletedHandler}
            onHide={() => setModalShow(false)}
          />
        </Col>
      </Row>

      <Paper sx={{ margin: "auto", marginTop: 3 }}>
        <ClientTable clients={clients} />
      </Paper>
    </Page>
  );
}

export default memo(Clients);
